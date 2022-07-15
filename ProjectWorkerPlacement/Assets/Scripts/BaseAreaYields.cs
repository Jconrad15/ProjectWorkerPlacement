public static class BaseAreaYields
{
    public static int GetBaseWoodYield(int meepleCount)
    {
        return AdditionFactorial(meepleCount);
    }

    public static int GetBaseFoodYield(int meepleCount)
    {
        return AdditionFactorial(meepleCount);
    }

    public static int GetBaseStoneYield(int meepleCount)
    {
        return AdditionFactorial(meepleCount);
    }

    public static int GetBasePopulationYield(int meepleCount)
    {
        return meepleCount <2 ? 0 : 1;
    }

    public static int GetBaseDefenseYield(int meepleCount)
    {
        return meepleCount;
    }

    public static int GetBaseWonderYield(int meepleCount)
    {
        return meepleCount;
    }

    private static int AdditionFactorial(int input)
    {
        return ((input * input) + input) / 2;
    }

}
