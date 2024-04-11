namespace MIG.API
{
    public interface IFactory<out TOutput>
    {
        TOutput Create();
    }

    public interface IFactory<out TOutput, in TInput>
    {
        TOutput Create(TInput input);
    }

    public interface IFactory<out TOutput, in TInput1, in TInput2>
    {
        TOutput Create(TInput1 input1, TInput2 input2);
    }
}