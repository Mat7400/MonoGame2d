using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace MonoGameOpenGLPong
{
    internal class Knight
    {
        Texture2D texture;
        Vector2 Postition;

        public Knight(Texture2D texture, Vector2 postition)
        {
            this.texture = texture;
            Postition = postition;
        }

    }
}
