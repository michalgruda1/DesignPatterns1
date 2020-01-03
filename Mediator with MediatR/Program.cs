using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Mediator_with_MediatR
{
	public class PingCommand : IRequest<PongResponse>
	{
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Code Quality", "IDE0052:Remove unread private members", Justification = "It is used via DI")]
		private readonly string Message;

		public PingCommand(string message)
		{
			Message = message;
		}
	}

	public class PongResponse
	{
		public DateTime Timestamp;

		public PongResponse(DateTime timestamp)
		{
			this.Timestamp = timestamp;
		}
	}

	public class PingCommandHandler : IRequestHandler<PingCommand, PongResponse>
	{
		public async Task<PongResponse> Handle(PingCommand request, CancellationToken cancellationToken)
		{
			return await Task.FromResult(new PongResponse(DateTime.UtcNow)).ConfigureAwait(false);
		}
	}


	public class Program
	{
		public static async Task Main(string[] args)
		{
			var services = new ServiceCollection();
			services.AddMediatR(Assembly.GetExecutingAssembly());
			var provider = services.BuildServiceProvider();
			var mediator = provider.GetRequiredService<IMediator>();

			var response = await mediator.Send(new PingCommand("To jest treść pinga"));

			Console.WriteLine(response.Timestamp);
		}
	}
}
