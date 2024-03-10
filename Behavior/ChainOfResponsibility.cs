namespace Patterns.Behavior.ChainOfResponsibility
{
    class Gun
    {
        public bool SingleShootSupport { get; set; }
        public bool BurstShootSupport { get; set; }
        public bool AutomaticShootSupport { get; set; }
        public ShootHandler ShootHandler { get; set; }

        public Gun(bool singleShootSupport, bool burstShootSupport, bool automaticShootSupport, ShootHandler shootHandler)
        {
            SingleShootSupport = singleShootSupport;
            BurstShootSupport = burstShootSupport;
            AutomaticShootSupport = automaticShootSupport;
            ShootHandler = shootHandler;
        }

        public void Fire()
        {
            ShootHandler.Handle(this);
        }
    }
    abstract class ShootHandler
    {
        public ShootHandler? NextHandler { get; set; }
        public abstract void Handle(Gun gun);
    }

    class SingleShootHandler : ShootHandler
    {
        public override void Handle(Gun gun)
        {
            if (gun.SingleShootSupport)
                Console.WriteLine("Buh!");
            else
                NextHandler?.Handle(gun);
        }
    }

    class BurstShootHandler : ShootHandler
    {
        public override void Handle(Gun gun)
        {
            if (gun.BurstShootSupport)
                Console.WriteLine("Buh! Buh! Buh!");
            else
                NextHandler?.Handle(gun);
        }
    }

    class AutomaticShootHandler : ShootHandler
    {
        public override void Handle(Gun gun)
        {
            if (gun.AutomaticShootSupport)
                Console.WriteLine("Buh! Buh! Buh! Buh! Buh! ...");
            else
                NextHandler?.Handle(gun);
        }
    }
}
