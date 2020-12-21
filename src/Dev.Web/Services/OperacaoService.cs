using System;

namespace Dev.Web.Services
{
    public class OperacaoService
    {
        public OperacaoService(IOperacaoTransient transient,
                               IOperacaoScoped scoped,
                               IOperacaoSingleton singleton,
                               IOperacaoSingletonIntance singletonInstance)
        {
            Transient = transient;
            Scoped = scoped;
            Singleton = singleton;
            SingleTonInstance = singletonInstance;
        }

        public IOperacaoTransient Transient { get; }

        public IOperacaoScoped Scoped { get; }

        public IOperacaoSingleton Singleton { get; }

        public IOperacaoSingletonIntance SingleTonInstance { get; }
    }

    public class Operacao : IOperacaoTransient,
                           IOperacaoScoped,
                           IOperacaoSingleton,
                           IOperacaoSingletonIntance
    {
        public Operacao() : this(Guid.NewGuid())
        {
        }

        public Operacao(Guid id)
        {
            OperacaoId = id;
        }

        public Guid OperacaoId { get; private set; }
    }

    public interface IOperacao
    {
        Guid OperacaoId { get; }
    }

    public interface IOperacaoTransient : IOperacao
    {

    }

    public interface IOperacaoScoped : IOperacao
    {

    }

    public interface IOperacaoSingleton : IOperacao
    {

    }

    public interface IOperacaoSingletonIntance : IOperacao
    {

    }
}