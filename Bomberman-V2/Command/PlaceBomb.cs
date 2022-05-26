
using SplashKitSDK;

namespace Bomberman_V2
{
    class PlaceBomb : Command
    {
        Player thePlayer;
        public PlaceBomb(Player newPlayer)
        {
            thePlayer = newPlayer;
        }
        public override void Execute()
        {
            Factory.Instance().InstantiateBomb(thePlayer);
        }
    }
}
