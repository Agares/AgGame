namespace AgaresGame.Engine.Resources.Graphics
{
	using System;

	using AgaresGame.Engine.Mathematics;
	using AgaresGame.Engine.Utils;

	using SDL2;

	public class Texture : IResource
	{
		private IntPtr pointer;

		private Texture()
		{
		}

		public int Height { get; set; }

		public int Width { get; set; }

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
			var texture = new Texture { pointer = pointer };

			uint bpp;
			int accessFlags, width, height;

			SDL.SDL_QueryTexture(texture.pointer, out bpp, out accessFlags, out width, out height);

			texture.Width = width;
			texture.Height = height;

			return texture;
		}

		public void Render(RenderContext renderContext, Rectangle source, Rectangle destination)
		{
			SDL.SDL_Rect sourceSdl = SdlRectUtils.FromRectangle(source);
			SDL.SDL_Rect destinationSdl = SdlRectUtils.FromRectangle(destination);

			SDL.SDL_RenderCopy(renderContext.Renderer, this.pointer, ref sourceSdl, ref destinationSdl);
		}

		public void RenderWhole(RenderContext context, Point2 destination)
		{
			this.Render(context, this.ComputeSourceRectangle(), this.ComputeDestinationRectangle(destination));
		}

		public void Dispose()
		{
			SDL.SDL_FreeSurface(this.pointer);
		}

		private Rectangle ComputeDestinationRectangle(Point2 destination)
		{
			var destinationRect = new Rectangle(destination, new Vector2(this.Width, this.Height));
			return destinationRect;
		}

		private Rectangle ComputeSourceRectangle()
		{
			var sourceRect = new Rectangle(Point2.Zero, new Vector2(this.Width, this.Height));
			return sourceRect;
		}
	}
}