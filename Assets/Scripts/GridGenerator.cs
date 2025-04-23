using System.Reflection;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    const int COLLUMNS = 13;
    const int ROWS = 13;
    const int COLLUMN_OFFSET = 2;
    const int ROW_OFFSET = 2;

    [SerializeField] GameObject UnbreakableWallPref;
    [SerializeField] GameObject BreakableWallPref;

    void Start()
    {
        GenerateUnbreakableWalls();
        GenerateBreakableWalls();
    }

    void GenerateUnbreakableWalls()
    {
        bool generateThisTile = false;

        generateThisTile = GenerateSpecialFirestAndLastBreakables(generateThisTile, 0);
        generateThisTile = GenerateSpecialSecondFirstAndLast(generateThisTile, 1);

        for(int i = 2; i < ROWS - 2; i++)
        {
            for (int j = 0; j < COLLUMNS; j++)
            {
                if (generateThisTile)
                {
                    GameObject newBreakable = Instantiate(BreakableWallPref, gameObject.transform);
                    newBreakable.transform.localPosition = new Vector3(j * COLLUMN_OFFSET, 1, -i * ROW_OFFSET);
                }
                generateThisTile = !generateThisTile;
            }
        }

        generateThisTile = GenerateSpecialSecondFirstAndLast(generateThisTile, ROWS-2);
        generateThisTile = GenerateSpecialFirestAndLastBreakables(generateThisTile, ROWS - 1);
    }

    private bool GenerateSpecialSecondFirstAndLast(bool generateThisTile, int row)
    {
        for (int j = 0; j < COLLUMNS; j++) ///ROW 1
        {
            if (generateThisTile)
            {
                if (j != 0 && j != COLLUMNS - 1)
                {

                    GameObject newBreakable = Instantiate(BreakableWallPref, gameObject.transform);
                    newBreakable.transform.localPosition = new Vector3(j * COLLUMN_OFFSET, 1, -row * ROW_OFFSET);
                }
            }
            generateThisTile = !generateThisTile;
        }

        return generateThisTile;
    }

    private bool GenerateSpecialFirestAndLastBreakables(bool generateThisTile, int row)
    {
        for (int j = 0; j < COLLUMNS; j++)   //ROW 0
        {
            if (generateThisTile)
            {
                if (j != 1 && j != COLLUMNS - 2)
                {
                    GameObject newBreakable = Instantiate(BreakableWallPref, gameObject.transform);
                    newBreakable.transform.localPosition = new Vector3(j * COLLUMN_OFFSET, 1, -row * ROW_OFFSET);
                }
            }
            generateThisTile = !generateThisTile;
        }
         return generateThisTile;
    }

    void GenerateBreakableWalls()
    {
        for(int i = 1; i < ROWS; i += 2)
        {
            bool generateThisTile = false;
            for (int j = 0; j < COLLUMNS; j++)
            {
                if (generateThisTile)
                {

                    GameObject newUnbreakable = Instantiate(UnbreakableWallPref, gameObject.transform);
                    newUnbreakable.transform.localPosition = new Vector3(j * COLLUMN_OFFSET, 1, -i * ROW_OFFSET);
                }
                generateThisTile = !generateThisTile;
            }
        }
    }
}
