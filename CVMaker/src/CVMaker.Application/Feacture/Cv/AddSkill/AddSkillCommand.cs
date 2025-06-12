using CVMaker.Application.Abstractions.Messaging;

namespace CVMaker.Application.Features.Cv.AddSkill
{
    // Representa un comando para agregar una habilidad al CV de un usuario
    public record AddSkillCommand(
        Guid UserId,
        Guid SkillId
    ) : ICommand;
}
