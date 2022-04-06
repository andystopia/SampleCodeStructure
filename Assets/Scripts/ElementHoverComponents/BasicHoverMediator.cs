namespace ElementHoverComponents
{
    public class BasicHoverMediator : HoverMediator
    {
        private IHoverBehaviour[] _hover;

        protected override void Awake()
        {
            _hover = GetComponents<IHoverBehaviour>();
            // very important, let the base class
            // awake as well.
            base.Awake();
        }
    

        public override void HoverEnterRequested()
        {
            foreach (var hoverBehaviour in _hover)
            {
                hoverBehaviour.OnHoverEnter();
            }
            base.HoverEnterRequested();
        }

        public override void HoverLeaveRequested()
        {        
            foreach (var hoverBehaviour in _hover)
            {
                hoverBehaviour.OnHoverLeave();
            }
            base.HoverLeaveRequested();
        }

    }
}