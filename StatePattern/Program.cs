internal class Program
{
    private static void Main(string[] args)
    {
        //Context context = new Context(new StateA());
        //context.Request(); //переход в состояние StateB
        //context.Request(); //переход в состояние StateA
        Water water = new Water(new LiquidWaterState());
        water.Heat();
        water.Heat();
        water.Heat();
        water.Frost();
        water.Frost();
        water.Frost();
        water.Frost();
        water.Heat();

        Console.ReadKey();
    }
}

//abstract class State
//{
//    public abstract void Handle(Context context);
//}

//class StateA : State
//{
//    public override void Handle(Context context)
//    {
//        context.state = new StateB();
//    }
//}

//class StateB : State
//{
//    public override void Handle(Context context)
//    {
//        context.state = new StateA();
//    }
//}

//class Context
//{
//    public State state { get; set; }

//    public Context(State _state)
//    {
//        state = _state;
//    }

//    public void Request()
//    {
//        state.Handle(this);
//    }
//}

interface IWaterState
{
    void Heat(Water water);
    void Frost(Water water);
}

class Water
{
    public IWaterState State { get; set; }

    public Water(IWaterState state)
    {
        State = state;
    }

    public void Heat()
    {
        State.Heat(this);
    }

    public void Frost()
    {
        State.Frost(this);
    }
}

class SolidWaterState : IWaterState
{
    public void Heat(Water water)
    {
        Console.WriteLine("Топим лед в жидкость");
        water.State = new LiquidWaterState();
    }

    public void Frost(Water water)
    {
        Console.WriteLine("Продолжаем заморозку льда");
    }
}

class LiquidWaterState : IWaterState
{
    public void Heat(Water water)
    {
        Console.WriteLine("Превращаем жидкость в пар");
        water.State = new GasWaterState();
    }

    public void Frost(Water water)
    {
        Console.WriteLine("Замораживаем жидкость в лед");
        water.State = new SolidWaterState();
    }
}

class GasWaterState : IWaterState
{
    public void Heat(Water water)
    {
        Console.WriteLine("Нагреваем пар");
    }

    public void Frost(Water water)
    {
        Console.WriteLine("Превращаем пар в жидкость");
        water.State = new LiquidWaterState();
    }
}