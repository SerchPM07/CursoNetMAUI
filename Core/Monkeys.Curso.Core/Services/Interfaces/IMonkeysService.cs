namespace Monkeys.Curso.Core.Services.Interfaces;

public interface IMonkeysService
{
    Task<List<Monkey>> GetMonkeys();
}
