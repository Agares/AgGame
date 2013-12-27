using System;
using AgaresGame.Engine.Mathematics;
using AgaresGame.Engine.Utils;
using SDL2;

namespace AgaresGame.Engine.Resources.Graphics
{
	public class Texture : IResource
	{
		private IntPtr _pointer;

		private Texture()
		{
		}

		public int Height { get; set; }
		public int Width { get; set; }

		public void Dispose()
		{
			SDL.SDL_FreeSurface(_pointer);
		}

		public static Texture FromSurface(RenderContext renderContext, IntPtr surface)
		{
			IntPtr texture = SDL.SDL_CreateTextureFromSurface(renderContext.Renderer, surface);
			if (texture == IntPtr.Zero)
			{
				throw new Exception(SDL.SDL_GetError());
			}

			return FromTexture(texture);
		}

		public static Texture FromTexture(IntPtr pointer)
		{
			var texture = new Texture {_pointer = pointer};

			uint bpp;
			int accessFlags, width, height;

			SDL.SDL_QueryTexture(texture._pointer, out bpp, out accessFlags, out width, out height);

			texture.Width = width;
			texture.Height = height;

			return texture;
		}

		public void Render(RenderContext renderContext, Rectangle source, Rectangle destination)
		{
			SDL.SDL_Rect sourceSdl = SdlRectUtils.FromRectangle(source);
			SDL.SDL_Rect destinationSdl = SdlRectUtils.FromRectangle(destination);

			SDL.SDL_RenderCopy(renderContext.Renderer, _pointer, ref sourceSdl, ref destinationSdl);
		}

		public void RenderWhole(RenderContext context, Point2 destination)
		{
			Render(context, ComputeSourceRectangle(), ComputeDestinationRectangle(destination));
		}

		private Rectangle ComputeSourceRectangle()
		{
			var sourceRect = new Rectangle(Point2.Zero, new Vector2(Width, Height));
			return sourceRect;
		}

		private Rectangle ComputeDestinationRectangle(Point2 destination)
		{
			var destinationRect = new Rectangle(destination, new Vector2(Width, Height));
			return destinationRect;
		}
	}
}