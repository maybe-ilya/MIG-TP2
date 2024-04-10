namespace MIG.API
{
    public interface IEnterableState : IState
    {
        void Enter();
    }

    public interface IEnterableState<in T> : IState
    {
        void Enter(T data);
    }

    public interface IEnterableState<in T1, in T2> : IState
    {
        void Enter(T1 data1, T2 data2);
    }
}