//---------------------------------------------------------
//1. Refactor the following class using best practices for 
// organizing straight-line code:
//---------------------------------------------------------
public class Chef
{	
	private Potato GetPotato() 
	{ 
		//... 
	}
	
	private Carrot GetCarrot() 
	{ 
		//... 
	}
	
	private void Peel(Vegetable vegetable) 
	{ 
		//... 
	}
	
	private void Cut(Vegetable vegetable) 
	{ 
		//... 
	}
	
	private Bowl GetBowl() 
	{   
		//... 
	}
	
	public void Cook() 
	{ 
		Potato potato = GetPotato(); 
		Peel(potato);
		Cut(potato); 
		
		Carrot carrot = GetCarrot(); 
		Peel(carrot); 
		Cut(carrot); 
		
		Bowl bowl = GetBowl(); 
		bowl.Add(potato);
		bowl.Add(carrot);
	}
}