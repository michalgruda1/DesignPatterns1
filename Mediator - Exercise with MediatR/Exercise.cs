using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Coding.Exercise
{
  public class Participant
  {
    public int Value { get; set; }
    private readonly Mediator mediator;

    public Participant(Mediator mediator)
    {
      this.mediator = mediator;
    }

    public void Say(int n)
    {
      mediator.SayHandler(n, this);
    }

    public void Hear(int n)
    {
      Value += n;
    }
  }

  public class Mediator
  {
    // todo
    public List<Participant> participants { get; set; } = new List<Participant>();

    public void AddParticipant(Participant participant)
    {
      participants.Add(participant);
    }

    public void SayHandler(int n, Participant source)
    {
      var receivers = participants.Where(p => !p.Equals(source));
      foreach (var receiver in receivers)
      {
        receiver.Hear(n);
      }
    }
  }

  class Program
  {
    public static void Main()
    {
      var mediator = new Mediator();
      var participant1 = new Participant(mediator);
      var participant2 = new Participant(mediator);
      mediator.AddParticipant(participant1);
      mediator.AddParticipant(participant2);

      var say1 = 3;
      var say2 = 2;

      Assert.Equal(participant1.Value, 0);
      Assert.Equal(participant2.Value, 0);

      participant1.Say(say1);
      Assert.Equal(participant1.Value, 0);
      Assert.Equal(participant2.Value, say1);

      participant2.Say(say2);
      Assert.Equal(participant1.Value, say2);
      Assert.Equal(participant2.Value, say1);


    }
  }
}
