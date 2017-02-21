using System;
using System.Collections;

public class Employ
{
    public string Name { set; get; }
    public string Surname { set; get; }
    public string Position { set; get; }
    public int Rent { set; get; }
    public Employ(string EName,string ESurname,string EPosition,int ERent)
    {

        Name=EName;
        Surname = ESurname;
        Position = EPosition;
        Rent = ERent;
    }

}

public class EmployeEnum : IEnumerator
{
    public Employ[] _employ;


    // Enumerators are positioned before the first element
    // until the first MoveNext() call.
    int position = -1;

    public EmployeEnum(Employ[] list)
    {
        _employ = list;
    }

    public bool MoveNext()
    {
        position++;
        return (position < _employ.Length);
    }

    public void Reset()
    {
        position = -1;
    }

   
    object IEnumerator.Current
    {
        get
        {
            return Current;
        }
    }



    public Employ Current
    {
        get
        {
            try
            {
                if (_employ[position].Rent >= 450000)
                    Console.WriteLine();
                    Console.WriteLine("super" +" "+ _employ[position].Name);
                   
                    return _employ[position];
            }
            catch (IndexOutOfRangeException)
            {
                throw new InvalidOperationException();
            }
        }
    }

}

public class Company:IEnumerable
{
    private Employ[] _employ;
    public Company(Employ[] _pArray)
    {

    
        _employ = new Employ[_pArray.Length];
        _employ = _pArray;
          
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return (IEnumerator)GetEnumerator();
    }


    



   public EmployeEnum GetEnumerator()
    {
        return new EmployeEnum(_employ);
    }

}





class App
{
    static void Main()
    {
        Employ[] EmployArray = new Employ[3]
        {
            new Employ("Conner", "p","Jenior",150000),
            new Employ("Houly", "Rate","Senior",600000),
            new Employ("Paul", "","Myddle",650000),
            
        };


        Company peopleList = new Company(EmployArray);
        foreach (Employ p in peopleList)
            Console.WriteLine(p.Name + " " + p.Surname + " " + p.Position + " " + p.Rent);

    }
}














