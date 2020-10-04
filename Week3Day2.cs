using System;
using System.Collections.Generic;

namespace Week3Day2 {
    class Program {
        static void Main(string[] args) {
            //PositionsOfHorizontalRoutes(5, 5, true , 0);
            PositionsOfHorizontalRoutes(50, 25, true, 1);
            PositionsOfHorizontalRoutes(50, 25, true, 2);
            PositionsOfHorizontalRoutes(50, 25, true, 3);
            PositionsOfHorizontalRoutes(5, 5, true, 1);
            PositionsOfHorizontalRoutes(5, 5, true, 2);
            PositionsOfHorizontalRoutes(5, 5, true, 3);
            PositionsOfHorizontalRoutes(50, 25, false, 1);
            PositionsOfHorizontalRoutes(50, 25, false, 2);
            PositionsOfHorizontalRoutes(50, 25, false, 3);
            PositionsOfVerticalRoutes(50, 25, true, 1);
            PositionsOfVerticalRoutes(50, 25, true, 2);
            PositionsOfVerticalRoutes(50, 25, true, 3);
            PositionsOfVerticalRoutes(50, 25, false, 1);
            PositionsOfVerticalRoutes(50, 25, false, 2);
            PositionsOfVerticalRoutes(50, 25, false, 3);

            DrawMap(5, 5);
        }
        // Week 3 Day 2 Mission 1: BOSS LEVEL Adventure map Part 2
        static void DrawMap(int width, int height) {
            var random = new Random();
            for (int y = 0; y < height; y++) {
                for (int x = 0; x < width; x++) {
                    // Draw frame
                    if ((x == 0 && y == 0) || (x == 0 && y == height - 1)) {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("+");
                    } else if ((x == width - 1 && y == 0) || (x == width - 1 && y == height - 1)) {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("+");
                    } else if ((x > 0) && (y == 0 || y == height - 1)) {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("-");
                    } else if ((x == 0 || x == width - 1) && (y > 0)) {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("|");
                    } else {
                        // We are in the map
                        int frameWidthPerRow = 2;
                        int ratioOfTheForest = 3; // its calculated 1/ratioOfTheForest
                        int forestArea = (width - frameWidthPerRow) / ratioOfTheForest;
                        if (x <= forestArea) {
                            int isTreePlaced = random.Next(0, x);
                            if (isTreePlaced < 1) {
                                Console.Write(GenerateTree());
                            } else {
                                Console.Write(" ");
                            }
                        } else {
                            Console.Write(" ");
                        }

                    }
                }

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        static string GenerateTree() {
            var random = new Random();
            List<string> treeCharacters = new List<string> { "A", "T", "@", "%", "(", ")" };
            int randomCharacter = random.Next(0, treeCharacters.Count);
            List<ConsoleColor> possibleTreeColors = new List<ConsoleColor> { ConsoleColor.Green, ConsoleColor.DarkGreen };
            int randomColor = random.Next(0, possibleTreeColors.Count);
            Console.ForegroundColor = possibleTreeColors[randomColor];
            return treeCharacters[randomCharacter];
        }

        // Week 3 Day 3 Mission 3: BOSS LEVEL Adventure map Part 3

        // Choose a random startpoint of the road in the left middle side of the map(2x1)
        static string PositionsOfHorizontalRoutes(int width, int height, bool start = true, int positionInRatio = 2, int ratio = 3) {
            const int CORRECTIONOFBORDERS = 1;
            const int CORRECTIONOFRATIO = 1;
            int heightRange = (height / ratio);
            Random random = new Random();
            if (positionInRatio >= ratio) {
                heightRange = random.Next(heightRange * (ratio - CORRECTIONOFRATIO), height - CORRECTIONOFBORDERS);
            } else if (positionInRatio <= 1) {
                heightRange = random.Next(CORRECTIONOFBORDERS, heightRange * positionInRatio + CORRECTIONOFBORDERS);
            } else {
                heightRange = random.Next(heightRange * (positionInRatio - CORRECTIONOFRATIO) + CORRECTIONOFBORDERS, heightRange * positionInRatio + CORRECTIONOFBORDERS);
            }
            string result = "";
            if (start) {
                result = $"({CORRECTIONOFBORDERS},{heightRange})";
            } else {
                result = $"({width - CORRECTIONOFBORDERS - CORRECTIONOFBORDERS},{heightRange})";
            }
            Console.WriteLine(result);
            return result;
        }


        // Choose a random startpoint of the river on the right side of the map (1x3)
        static string PositionsOfVerticalRoutes(int width, int height, bool start = true, int positionInRatio = 2, int ratio = 3) {
            const int CORRECTIONOFBORDERS = 1;
            const int CORRECTIONOFRATIO = 1;
            int widthRange = (width / ratio);
            Random random = new Random();
            if (positionInRatio >= ratio) {
                widthRange = random.Next(widthRange * (ratio - CORRECTIONOFRATIO), width - CORRECTIONOFRATIO);
            } else if (positionInRatio <= 1) {
                widthRange = random.Next(CORRECTIONOFBORDERS, widthRange * positionInRatio + CORRECTIONOFBORDERS);
            } else {
                widthRange = random.Next(widthRange * (positionInRatio - CORRECTIONOFRATIO) + CORRECTIONOFBORDERS, widthRange * positionInRatio + CORRECTIONOFBORDERS);
            }
            string result = "";
            if (start) {
                result = $"({widthRange},{CORRECTIONOFBORDERS})";
            } else {
                result = $"({widthRange},{height - CORRECTIONOFBORDERS - CORRECTIONOFBORDERS})";
            }
            Console.WriteLine(result);
            return result;
        }

        // Choose a random startpoint of the road in the right middle of the map (2x2)
        static string StartPositionIntersection(int width, int height) {
            string result = "";

            return result;
        }

        static string StartPositionBridge(int width, int height) {
            string result = "";

            return result;
        }

        static string EndPositionBridge(int width, int height) {
            string result = "";

            return result;
        }

        static string CenterTopPositionBridge(int width, int height) {
            string result = "";

            return result;
        }

        static string CenterBottomPositionBridge(int width, int height) {
            string result = "";

            return result;
        }

        static List<string> GenerateBridge(int width, int height) {
            List<string> result = new List<string>();

            return result;
        }





        // Week 3 Day 2 Mission 1: BOSS LEVEL Adventure map Part 1
        /*
         * 1. List of Elements:
         * A frame for the Map
         * A Title for the map
         * Trees on the left side
         * A road from left frame to the right frame 
         * A bridge over the river and along the road
         * A river from top to bottom and under the bridge until it hits the frame
         * A road left of the river from top to bottom until it hits the frame
         * 
         * 2.1. Preperation:
         * What do we need? (O = considered, X = still need to be considered)
         * (O) Position of title 
         * (O) Startposition road
         * (O) Startposition river
         * (O) Endposition road
         * (O) Endposition river
         * (O) Intersection river and road
         * (O) Where is the road
         * (O) Flow of the river
         * (O) Startpoint road next to river
         * (O) Endpoint road next to river
         * 
         * Divide the Map into 3x3 sections
         * (1,1)(1,2)(1,3)
         * (2,1)(2,2)(2,3)
         * (3,1)(3,2)(3,3)
         * 
         * Check if there is enough space for the title
         * Calculate the title first, so that you see how much space you have available left and right
         * Place the title in the center
         * Choose a random startpoint of the river on the right side of the map (1x3)
         * The river can't end on the right frame
         * Choose a random endpoint of the river on the right side of the map (3x3)
         * The river can't end on the right frame
         * Choose a random startpoint of the road in the left middle side of the map (2x1)
         * Choose a random startpoint of the road in the right middle of the map (2x2)
         * Choose a random endpoint of the road in the right middle side of the map (2x3)
         * Build path from start of the road to start of the river road
         * Build path to the right from start of the river road until you reach edge of right middle (2x3)
         * Place there the bridge
         * Build path from end of the bridge to the endplace of the road
         * Build river from the startpoint of the river to the center of the bridge
         * Build river from the center of the bridge to the end of the river
         * Build path left of the river from startpoint of the river road to endpoint of river road
         * 
         * 
         * 2.2 Drawing
         * Yellow corner with the characters + - |
         * Yellow text in the top center: "ADVENTURE MAP"
         * Green and DarkGreen trees with the characters A T @ % ( )
         * White road with the character #
         * DarkGray bridge with the character =
         * DarkMagenta river with the characters | / \
         * 
         * 3 On the Fly:
         * Frame
         * Title
         * 
         * 4. preparation phase:
         * roads, river, bridge and trees
         * 
         * 5. Positions
         * Check if there is enough space for the title
         * Calculate the title first, so that you see how much space you have available left and right
         * Place the title in the center
         * Choose a random startpoint of the river on the right side of the map (1x3)
         * The river can't end on the right frame
         * Choose a random endpoint of the river on the right side of the map (3x3)
         * The river can't end on the right frame
         * Choose a random startpoint of the road in the left middle side of the map (2x1)
         * Choose a random startpoint of the road in the right middle of the map (2x2)
         * Choose a random endpoint of the road in the right middle side of the map (2x3)
         * 
         * 6./7. dependencies
         * First get the Title
         * Then the roads
         * Then the river
         * Then the river road
         * Then the trees
         * 
         * 8.
         * Title
         * Road
         * Bridge
         * River
         * Trees
         * 
         * 9.
         * Check if there is enough space for the title
         * Calculate the title first, so that you see how much space you have available left and right
         * Place the title in the center
         * Choose a random startpoint of the river on the right side of the map (1x3)
         * The river can't end on the right frame
         * Choose a random endpoint of the river on the right side of the map (3x3)
         * The river can't end on the right frame
         * Choose a random startpoint of the road in the left middle side of the map (2x1)
         * Choose a random startpoint of the road in the right middle of the map (2x2)
         * Choose a random endpoint of the road in the right middle side of the map (2x3)
         * Build path from start of the road to start of the river road
         *      Building happens from left to right
         *      Start at startpoint of the path
         *      In the next column the path have to be adjacent (x+=1)(y+=random.Next(-1,2))
         *      Check if the startpoint of the river road is still reachable
         *          int alreadyFixedPointOnTheWay = 1
         *          int statement = startpoint.riverpath.x - path.x -alreadyFixedPointOnTheWay - |startpoint.riverpath.y - path.y|
         *      if statement >= 2 then y+=random.Next(-1,2) // You are free to choose randomly
         *      else if statement == 1 then 
         *          if startpoint.riverpath.y > path.y then y+=random.Next(0,2) // when the path is below, you can't go further down
         *          else y+=random.Next(-1,1) // When the path is higher, then you can't go higher anymore
         *      else if statement == 0 then 
         *          if startpoint.riverpath.y > path.y then y+=1 // go straight to the startpoint.riverpath
         *          else y-=1 // go straight to the startpoint.riverpath
         * Because there are many uses of this pathfinding, I would make a method out of this
         * I will put all the results in a list as a already placed spot
         * Build path to the right from start of the river road until you reach edge of right middle (2x3)
         *      use the method
         * Place there the bridge
         *      The brigde would be a constant building
         *      Build it from left to right
         *      If the bridge hits the frame of the map, then don't go any further and delete the endpoint of the path
         * Build path from end of the bridge to the endplace of the road
         *      use the method
         * Build river from the startpoint of the river to the center of the bridge
         *      So far I have made it from left to right, so that i now need also the same method from top to bottom
         *      There must be also a river flag, because I need to mark not one character but 3 at the same time
         *      but there ist still the same algorithm just with different start and endpoints
         * Build river from the center of the bridge to the end of the river
         *      use the new methode
         * Build path left of the river from startpoint of the river road to endpoint of river road
         *      use the new methode
         * Now when everything is in place, then start placing the trees
         *      Every row you place a random tree directly to the frame
         *      Now go from left to the right until the end of the forest (right end of the column (x,1)) 
         *      and maybe place a tree
         * */
    }
}
