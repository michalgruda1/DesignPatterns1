using Stateless;
using Stateless.Graph;
using System;

namespace State_with_Stateless
{
	enum Health
	{
		NonReproductive,
		Pregnant,
		Reproductive
	}
	
	enum Activity {
		GiveBirth,
		ReachPuberty,
		HaveAbortion,
		HaveUnprotectedSex,
		Historectomy,

	}

	class Program
	{
		public static bool AreParentsWatching;

		static void Main(string[] args)
		{
			var reproductiveHealth = new StateMachine<Health, Activity>(Health.NonReproductive);

			reproductiveHealth
				.Configure(Health.NonReproductive)
				.Permit(Activity.ReachPuberty, Health.Reproductive);

			reproductiveHealth
				.Configure(Health.Reproductive)
				.PermitIf(Activity.HaveUnprotectedSex, Health.Pregnant, () => !AreParentsWatching, "If parents are watching, can't have unprotected sex")
				.Permit(Activity.Historectomy, Health.NonReproductive);

			reproductiveHealth
				.Configure(Health.Pregnant)
				.Permit(Activity.GiveBirth, Health.Reproductive)
				.Permit(Activity.HaveAbortion, Health.Reproductive);

			string graphDot = UmlDotGraph.Format(reproductiveHealth.GetInfo());

			// just output the graph
			Console.WriteLine(graphDot);
		}
	}
}
