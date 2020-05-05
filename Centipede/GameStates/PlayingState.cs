#region Using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pacman;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pacman.GameObjects;
#endregion

namespace Pacman.GameStates
{
    class PlayingState : GameObjectList
    {
        public Random random = new Random();

        PacManGameObject pacman;

        #region Ghosts
        Fraude fraude;
        Smite smite;
        Virus virus;
        Sleep sleep;
        static public GameObjectList spookjes = new GameObjectList();
        #endregion

        #region Points
        Points points;
        static public GameObjectList punten = new GameObjectList();
        #endregion

        public PlayingState()
        {
            Reset();
        }

        #region Reset
        public override void Reset()
        {

            fraude = new Fraude(new Vector2(75, 75));
            smite = new Smite(new Vector2(125, 75));
            virus = new Virus(new Vector2(175, 75));
            sleep = new Sleep(new Vector2(225, 75));

            pacman = new PacManGameObject(new Vector2(75, 125));

            points = new Points(new Vector2(random.Next(50, 650), random.Next(50, 950)));

            this.Add(punten);
            punten.Add(points);

            this.Add(spookjes);
            spookjes.Add(fraude);
            spookjes.Add(smite);
            spookjes.Add(virus);
            spookjes.Add(sleep);

            this.Add(pacman);

            base.Reset();
        }
        #endregion

        public override void Update(GameTime gameTime)
        {
            if (CollidesWithPacman(pacman))
            {

            }

            base.Update(gameTime);
        }

        public bool CollidesWithPacman(PacManGameObject pacman)
        {
            bool temp = false;
            foreach (Points points in punten.Children)
            {
                if (points.CollidesWith(pacman))
                {
                    temp = true;
                }
            }
            return temp;
        }
    }
}