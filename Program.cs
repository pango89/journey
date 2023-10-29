using JourneyLLD;

internal class Program
{
    private static void Main(string[] args)
    {
        JourneyController jc = new();

        User u1 = jc.AddUser();
        User u2 = jc.AddUser();
        // User u3 = jc.AddUser();
        // User u4 = jc.AddUser();
        // User u5 = jc.AddUser();

        /* 
        Journey - 1
        Stages = [A, B, C, D]
        1st Stage = A, Last Stage = D
        Adjacency List = 
        A -> [B, C, D]
        B -> [D]
        C -> [D]
        */

        Journey j1 = jc.CreateJourney(
            new List<string> { "A", "B", "C", "D" },
            new() { { "A", new List<string>() { "B", "C", "D" } }, { "B", new List<string>() { "D" } }, { "C", new List<string>() { "D" } } },
            new() { { "A", new List<string>() { "k1", "k2" } }, { "B", new List<string>() { "k3", "k4" } }, { "C", new List<string>() { "k5", "k6" } }, { "D", new List<string>() { "k7", "k8" } } });

        /* 
        Journey - 2
        Stages = [X, Y, Z]
        1st Stage = X, Last Stage = Z
        Adjacency List = 
        X -> [Y, Z]
        Y -> [Z]
        */

        Journey j2 = jc.CreateJourney(
            new List<string> { "X", "Y", "Z" },
            new() { { "X", new List<string>() { "Y", "Z" } }, { "Y", new List<string>() { "Z" } } },
            new() { { "X", new List<string>() { "k5", "k6" } }, { "Y", new List<string>() { "k7", "k8" } }, { "Z", new List<string>() { "k1", "k2" } } });

        jc.UpdateState(j1.Id, JourneyState.ACTIVE);
        jc.UpdateState(j2.Id, JourneyState.ACTIVE);

        jc.Print();

        jc.Evaluate(u1.Id, new() { { "k1", "" }, { "k2", "" } });
        jc.Print();

        jc.Evaluate(u2.Id, new() { { "k1", "" }, { "k2", "" } });
        jc.Print();

        jc.Evaluate(u2.Id, new() { { "k5", "" }, { "k6", "" } });
        jc.Print();

        jc.Evaluate(u1.Id, new() { { "k5", "" }, { "k6", "" } });
        jc.Print();

        jc.Evaluate(u2.Id, new() { { "k1", "" }, { "k2", "" } });
        jc.Print();


        Console.WriteLine();
    }
}