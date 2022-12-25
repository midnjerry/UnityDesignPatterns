namespace Chapter.Visitor
{
    public interface IBikeElement
    {
        void Accept(IVisitor visitor);
    }
}
