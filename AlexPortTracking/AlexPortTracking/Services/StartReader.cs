using AlexPortTracking.Data;
using AlexPortTracking.Migrations;
using AlexPortTracking.Models;
using Azure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SocketHandler;

namespace AlexPortTracking.Services
{
    public record SocketsWithReaders(SocketHandler.SocketHandler socket, List<Reader> readers);
    public class StartReader: BackgroundService
    {
        public AlexPortTrackingDbContext context { get; set; }
        private readonly IServiceProvider serviceProvider;

        public List<SocketsWithReaders> sockets { get; set; }
        List<IGrouping<int, Reader>> portsToOpen { get; set; }
        public StartReader(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }


        public async Task<List<Reader>> GetAllReaders() =>
            await context.Readers.ToListAsync();

        public async Task<bool> GetReaderOperation(string tag, SocketHandler.SocketHandler socket)
        {
            try
            {
                var sock = sockets.Where(s => object.ReferenceEquals(s.socket, socket)).First();
                var reader = sock.readers.Where(r => tag.StartsWith(r.Signature) && tag.EndsWith(r.Signature)).First();
                // 1001,800341002C,0E,3000,4E201909,36FA4,000000000,01,1001


                tag = tag.Substring(reader.Signature.Length, tag.Length - reader.Signature.Length);
                var carTag = tag.Substring(24, 5);

                var car = await context.Cars.FirstOrDefaultAsync(c => c.FrontTag == carTag || c.RearTag == carTag);
                await context.TransactionLogs.AddAsync(new TransactionLog {
                    ReaderId = reader.Id,
                    CarId = car?.Id,
                    Tag = tag,
                });
                await context.SaveChangesAsync();


                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }

        }   

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            this.context = serviceProvider.CreateScope().ServiceProvider.GetRequiredService<AlexPortTrackingDbContext>();
            sockets = new List<SocketsWithReaders>();
            var readers = await GetAllReaders();
            portsToOpen = readers.GroupBy(r => r.PortNumber).ToList();
            foreach (var port in portsToOpen)
            {
                var socket = new SocketHandler.SocketHandler((uint)port.Key, this.GetReaderOperation);
                sockets.Add(new SocketsWithReaders(socket, port.ToList()));
                await socket.Connect();
                

            }
        }
    }
}
