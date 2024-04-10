namespace MIG.API
{
    public interface IStateMachine
    {
        void ChangeState<TState>() where TState : IEnterableState;
        void ChangeState<TState, TData>(TData data) where TState : IEnterableState<TData>;

        void ChangeState<TState, TData1, TData2>(TData1 data1, TData2 data2)
            where TState : IEnterableState<TData1, TData2>;
    }
}