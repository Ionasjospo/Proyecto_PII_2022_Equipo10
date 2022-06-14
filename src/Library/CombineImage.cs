using ImageMagick;

namespace Library
{
    /// <summary>
    /// Clase que combina imagenes para el board.
    /// </summary>
    public class CombineImage
    {
        /// <summary>
        /// Imagen la cual va de fondo.
        /// </summary>
        private string fondo = "";
        /// <summary>
        /// Imagen a superponer.
        /// </summary>
        /// <summary>
        /// Path de la imagen.
        /// </summary>
        private string image = "";
        /// <summary>
        /// Posisión en el eje x.
        /// </summary>
        private int x;
        /// <summary>
        ///  Posisión en el eje y.
        /// </summary>
        private int y;

        private int i = 0;

        /// <summary>
        /// Método el cual combina imagenes y asigna su posicion.
        /// </summary>
        /// <param name="fondoPath">Imagen de fondo.</param>
        /// <param name="imagePath">Imagen a superponer.</param>
        /// <param name="xpos">Posisión x</param>
        /// <param name="ypos">Posisión y</param>
        public void MergeMultipleImages(string fondoPath, string imagePath, int xpos, int ypos)
        {
            this.fondo = fondoPath;
            this.image = imagePath;
            this.x = xpos;
            this.y = ypos;
           
            
            using (var images = new MagickImageCollection())
            {
                // Add the first image
                var first = new MagickImage(fondo);//burrito
                images.Add(first);

                // Add the second image
                var second = new MagickImage(image);//cola
                images.Add(second);

                //var third = new MagickImage(submarine);//cola
                //images.Add(third);

                // Create a mosaic from both images
                using (var result = images.Mosaic())
                {
                    // Save the result
                    first.Composite(second, x, y, CompositeOperator.Over);
    
                    first.Write(@$"..\Program\FinalImage.jpg");
                    i++;
                    //first.Write(@$"..\Program\User{user.id}.jpg");
                    //{match_id}_{user_id}_FinalImage_{numero}
                }
            }
        }
    }
}