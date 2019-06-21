using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class Grid
    {
        public Cell[,] grid;
        public int gridWidth;
        public int gridHeight;
        public Grid(int width, int height)
        {
            gridWidth = width;
            gridHeight = height;
            grid = new Cell[width,height];
            for(int j=0; j<height;j++)
            {
                for (int i = 0; i < width; i++)
                {
                    grid[i,j] = new Cell();
                }
            }
        }
        public void checkGrid()
        {
            Cell[,] temp = new Cell[gridWidth, gridHeight];
            for (int j = 0; j < gridHeight; j++)
            {
                for (int i = 0; i < gridWidth; i++)
                {
                    temp[i, j] = new Cell();
                }
            }
            int aliveNeighbors = 0;
            for (int j = 0; j < gridHeight; j++)
            {
                for (int i = 0; i < gridWidth; i++)
                {
                    int x1 = i - 1;
                    int x2 = i + 1;
                    int y1 = j - 1;
                    int y2 = j + 1;
                    if (i == 0)
                        x1 = gridWidth - 1;
                    else if (i == gridWidth - 1)
                        x2 = 0;
                    if (j == 0)
                        y1 = gridHeight - 1;
                    else if (j == gridHeight - 1)
                        y2 = 0;

                    aliveNeighbors = 0;
                    if (grid[x1, y1].value)
                        aliveNeighbors++;
                    if (grid[x1, j].value)
                        aliveNeighbors++;
                    if (grid[x1, y2].value)
                        aliveNeighbors++;
                    if (grid[i, y1].value)
                        aliveNeighbors++;
                    if (grid[i, y2].value)
                        aliveNeighbors++;
                    if (grid[x2, y1].value)
                        aliveNeighbors++;
                    if (grid[x2, j].value)
                        aliveNeighbors++;
                    if (grid[x2, y2].value)
                        aliveNeighbors++;

                    if(grid[i, j].value)
                    {
                        if (aliveNeighbors == 2 || aliveNeighbors == 3)
                        {
                            temp[i, j].value = true;
                        }
                        else
                        {
                            temp[i, j].value = false;
                        }
                    }
                    else
                    {
                        if(aliveNeighbors==3)
                        {
                            temp[i, j].value = true;
                        }
                        else
                        {
                            temp[i, j].value = false;
                        }
                    }
                }
            }
            grid = temp;
        }
    }
}
