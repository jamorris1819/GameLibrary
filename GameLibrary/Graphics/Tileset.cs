using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace GameLibrary.Graphics
{
    /// <summary>
    /// A class which holds all the individual images in a tileset.
    /// </summary>
    public class Tileset
    {
        private GraphicsDevice graphicsDevice;

        private Vector2 dimensions;
        private Vector2 tileDimensions;

        private Texture2D baseImage;
        private Texture2D[,] tiles;

        /// <summary>
        /// Returns the width in pixels of the tileset.
        /// </summary>
        public int Width
        {
            get { return (int)dimensions.X; }
        }

        /// <summary>
        /// Returns the height in pixels of the tileset.
        /// </summary>
        public int Height
        {
            get {  return (int)dimensions.Y; }
        }

        /// <summary>
        /// Returns the dimensions of each individual tile.
        /// </summary>
        public Vector2 TileDimensions
        {
            get { return tileDimensions; }
        }

        /// <summary>
        /// Constructor for the tileset class.
        /// </summary>
        /// <param name="baseImage">Image to use for the tileset</param>
        /// <param name="tileDimensions">Size of each tile</param>
        public Tileset(GraphicsDevice graphicsDevice, Texture2D baseImage, Vector2 tileDimensions)
        {
            this.dimensions = new Vector2(baseImage.Width, baseImage.Height);
            this.graphicsDevice = graphicsDevice;
            this.tileDimensions = tileDimensions;
            this.baseImage = baseImage;
            Process();
        }

        /// <summary>
        /// Processes the tileset image and populates the tile array.
        /// </summary>
        private void Process()
        {
            tiles = new Texture2D[(int)(dimensions.X / tileDimensions.X), (int)(dimensions.Y / tileDimensions.Y)];
            for (int i = 0; i < dimensions.X / tileDimensions.X; i++)
            {
                for (int j = 0; j < dimensions.Y / tileDimensions.Y; j++)
                {
                    Texture2D imagePiece = new Texture2D(graphicsDevice, (int)tileDimensions.X, (int)tileDimensions.Y);
                    Color[] data = new Color[(int)(tileDimensions.X * tileDimensions.Y)];
                    // Take the color data from the area we want.
                    baseImage.GetData(0, new Rectangle(i * (int)tileDimensions.X, j * (int)tileDimensions.Y, (int)tileDimensions.X, (int)tileDimensions.Y), data, 0, data.Length);
                    // Copy it into our new piece.
                    imagePiece.SetData(data);
                    tiles[i, j] = imagePiece;
                }
            }
        }

        /// <summary>
        /// Returns the tile at the specified position.
        /// </summary>
        /// <param name="x">X coordinate of tile</param>
        /// <param name="y">Y coordinate of tile</param>
        /// <returns></returns>
        public Texture2D GetTile(int x, int y)
        {
            return tiles[x, y];
        }
    }
}
