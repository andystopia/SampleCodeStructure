
namespace ElementHoverComponents
{
    /**
 * This interface describes what it means
 * for an element to be hovered. Note
 * that you might think that "well, we
 * would never need this, but on the
 * contrary, it is very useful
 * because hovering can also be done
 * when the keyboard tabs over the
 * input for instance.
 */
    public interface IHoverBehaviour
    {
        void OnHoverEnter();
        void OnHoverLeave();
    }
}