﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace TGC.MonoGame.TP
{
    public class Ship
    {
        ContentManager content;
        private Matrix World { get; set; }
        private Model Model { get; set; }
        public Vector3 Position;
        private Matrix Scale;
        private Matrix Rotation;
        private FollowCamera FollowCamera;

        public Ship(ContentManager content, FollowCamera FollowCamera)
        {
            this.FollowCamera = FollowCamera;
            this.content = content;
            Scale = Matrix.CreateScale(0.015f);
            Rotation = Matrix.CreateRotationX(0) * Matrix.CreateRotationY(0) * Matrix.CreateRotationZ(0);

            World = Scale * Rotation * Matrix.CreateTranslation(Position);
        }
        public void Load(String path)
        {
            Model = content.Load<Model>(path);
        }

        public void update(GameTime gameTime)
        {

            World = Scale * Rotation * Matrix.CreateTranslation(Position);
            FollowCamera.Update(gameTime, Matrix.Identity);
        }
        
        public void Draw(Matrix view, Matrix proj)
        {
            Model.Draw(World, view, proj);
        }

    }


}
