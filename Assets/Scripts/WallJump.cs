using System;
namespace Application
{
    public class WallJump: Item
    {
        public override void onPickup()
        {
            player.GetComponent<Player>().ActivateWallJump();
        }
    }
}
