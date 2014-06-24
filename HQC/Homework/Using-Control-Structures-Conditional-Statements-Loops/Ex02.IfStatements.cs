Potato potato;
//... 
if (potato == null)
{
    return;
}

if(potato.IsPeeled && potato.IsNotRotten)
{
    Cook(potato);
}

//-----------------------------------------------------------------------------

IsInRange(double coord, double minRange, double maxRange)
{
    bool result = coord >= minRange && coord <= maxRange;
	return result;
}

if (IsInRange(x, MIN_X, MAX_X) && IsInRange(y, MIN_Y, MAX_Y) && shouldVisitCell)
{
    VisitCell();
}