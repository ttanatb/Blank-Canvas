﻿using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace blank_canvas
{
    /// <summary>
    /// Class that manages all the textures that 
    /// need to be passed in.
    /// </summary>
    class GameContent : Microsoft.Xna.Framework.Game
    {
        Dictionary<string, Texture2D> dict = new Dictionary<string, Texture2D>();

        Texture2D testTexture;
        SpriteFont testFont;
        Texture2D heartHealth;
        Texture2D guiBox;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="game"></param>
        public GameContent(ContentManager content)
        {
            dict.Add("player", content.Load<Texture2D>(@"sprite\playerSpriteSheet"));
            dict.Add("enemy", content.Load<Texture2D>(@"sprite\enemySpriteSheet"));
            dict.Add("tile", content.Load<Texture2D>(@"sprite\tileSpritesheet"));
            dict.Add("projectile", content.Load<Texture2D>(@"sprite\projectile"));
            dict.Add("orbBase", content.Load<Texture2D>(@"sprite\orbBase"));
            dict.Add("orb", content.Load<Texture2D>(@"sprite\orb"));
            dict.Add("orbGlow", content.Load<Texture2D>(@"sprite\orbGlow"));
            dict.Add("door", content.Load<Texture2D>(@"sprite\door"));
            dict.Add("pointer", content.Load<Texture2D>(@"sprite\pointer"));
            dict.Add("finalOrb", content.Load<Texture2D>(@"sprite\finalOrbSpriteSheet"));

            dict.Add("mainMenu", content.Load<Texture2D>(@"screen\mainmenu"));
            dict.Add("pause", content.Load<Texture2D>(@"screen\pause"));
            dict.Add("gameOver", content.Load<Texture2D>(@"screen\gameover"));
            dict.Add("instruction", content.Load<Texture2D>(@"screen\instruction"));

            dict.Add("levelChange", content.Load<Texture2D>("testlevelchange"));
            dict.Add("testBackground", content.Load<Texture2D>("testBackground"));

            dict.Add("bg0", content.Load<Texture2D>(@"bg\bg0"));
            dict.Add("bg1", content.Load<Texture2D>(@"bg\bg1"));
            dict.Add("bg2", content.Load<Texture2D>(@"bg\bg2"));
            dict.Add("bg3", content.Load<Texture2D>(@"bg\bg3"));
            dict.Add("bg4", content.Load<Texture2D>(@"bg\bg4"));
            dict.Add("bg5", content.Load<Texture2D>(@"bg\bg5"));

            testTexture = content.Load<Texture2D>("blank_canvas_GUI_box");
            testFont = content.Load<SpriteFont>("Arial_14");
            heartHealth = content.Load<Texture2D>("hearthealth");
            guiBox = content.Load<Texture2D>("guiBoxRounded");
        }

        /// <summary>
        /// Searches for each texture within the dictionary
        /// </summary>
        /// <param name="str"> takes in string to search for texture </param>
        public Texture2D Load(string str)
        {
            if (dict.ContainsKey(str))
            {
                return dict[str];
            }
            else
                return null;
        }

        public Texture2D TestTexture { get { return testTexture; } }

        public Texture2D HeartHealth { get { return heartHealth; } }

        public Texture2D GuiBox { get { return guiBox; } }

        public SpriteFont TestFont {  get { return testFont; } }
    }
}
