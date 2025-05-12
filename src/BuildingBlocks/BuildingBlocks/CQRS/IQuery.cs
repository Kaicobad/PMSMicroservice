namespace BuildingBlocks.CQRS;
public interface IQuery<out IResponse>: IRequest<IResponse>
    where IResponse : notnull
{
}
