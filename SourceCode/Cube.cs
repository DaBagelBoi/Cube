using System.Text;
using ConsoleExtender;

namespace ConsoleApp
{
    class Cube
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.Title = "Cube.cs";
            ConsoleHelper.SetCurrentFont("Consolas", 8);
            
            var display = new Display(new Vector2Int(60, 60));

            float distanceFromCamera = 3.2f;
            float cubeSize = 45f;
            float rotationPerStep = 1f;
            float timeDelay = 0.01f;
            float angle = 0.0f;

            //original positions of the points
            var ogPositions = new Vector3Int[8]
            {
                new Vector3Int(-1, -1, 1),
                new Vector3Int(1, -1, 1),
                new Vector3Int(1, 1, 1),
                new Vector3Int(-1, 1, 1),
                new Vector3Int(-1, -1, -1),
                new Vector3Int(1, -1, -1),
                new Vector3Int(1, 1, -1),
                new Vector3Int(-1, 1, -1)
            };

            //position of points on the display
            var positionsOnDisplay = new Vector2Int[8];

            //positions after the rotation
            var transformedPositions = new Vector3[8];

            while (true)
            {
                angle += rotationPerStep;

                //cube looks same after 90 degree rotation, so return it to a similar rotation
                if ((double)angle > 90.0)
                    angle -= 90f;
                
                //croject 3D transformation to 2D display
                for (int i = 0; i < 8; ++i)
                {
                    transformedPositions[i].x = (float)((double)ogPositions[i].x * (double)cos(angle * ((float)Math.PI / 180f)) - (double)ogPositions[i].z * (double)sin(angle * ((float)Math.PI / 180f)));
                    transformedPositions[i].y = (float)ogPositions[i].y;
                    transformedPositions[i].z = (float)((double)ogPositions[i].x * (double)sin(angle * ((float)Math.PI / 180f)) + (double)ogPositions[i].z * (double)cos(angle * ((float)Math.PI / 180f))) - distanceFromCamera;
                    positionsOnDisplay[i].x = display.Resolution.x / 2 + (int)Math.Round((double)transformedPositions[i].x / (double)transformedPositions[i].z * (double)cubeSize);
                    positionsOnDisplay[i].y = display.Resolution.y / 2 + (int)Math.Round((double)transformedPositions[i].y / (double)transformedPositions[i].z * (double)cubeSize);
                }

                //clear display
                display.Clear(' ');

                //draw the lines between each point
                display.DrawLines(
                    //front face
                    positionsOnDisplay[0], positionsOnDisplay[1],
                    positionsOnDisplay[1], positionsOnDisplay[2],
                    positionsOnDisplay[2], positionsOnDisplay[3],
                    positionsOnDisplay[3], positionsOnDisplay[0],

                    //back face
                    positionsOnDisplay[4], positionsOnDisplay[5],
                    positionsOnDisplay[5], positionsOnDisplay[6],
                    positionsOnDisplay[6], positionsOnDisplay[7],
                    positionsOnDisplay[7], positionsOnDisplay[4],

                    //connecting lines
                    positionsOnDisplay[0], positionsOnDisplay[4],
                    positionsOnDisplay[1], positionsOnDisplay[5],
                    positionsOnDisplay[2], positionsOnDisplay[6],
                    positionsOnDisplay[3], positionsOnDisplay[7]
                    );

                //print display to console
                display.Print();

                Thread.Sleep((int)((double)timeDelay * 1000.0));
            }

            float cos(float m) => (float)Math.Cos((double)m);
            float sin(float m) => (float)Math.Sin((double)m);
        }
    }
}
