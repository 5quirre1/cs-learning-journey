using System;

namespace BoolStuff
{
  class Program
  {
    static void Main(string[] args)
    {
      // friend wants to go to a place
      bool friendWantsToGoToMcDonalds = true;
      bool friendWantsToGoToWendys = false;
      bool friendWantsToGoToWow = true;

      // where you want to go
      bool uWantsToGoToMcDonalds = true;
      bool uWantsToGoToWendys = false;
      bool uWantsToGoToWow = false;

      // put all of the friendwants variables in one
      bool[] friendsWantPlace = {
        friendWantsToGoToMcDonalds,
        friendWantsToGoToWendys,
        friendWantsToGoToWow
      };

      // your want place in one variable
      bool[] uWantPlace = {
        uWantsToGoToMcDonalds,
        uWantsToGoToWendys,
        uWantsToGoToWow
      };

      // check if there is at least one match
      bool check = false;
      for (int i = 0; i < friendsWantPlace.Length; i++)
      {
        if (friendsWantPlace[i] && uWantPlace[i])
        {
          check = true;
          break;
        }
      }

      if (check) // if had both at least one place
      {
        Console.WriteLine("you and friend wanted to go to atleast one of the same places!");
      }
      else // no same place
      {
        Console.WriteLine("you and friend didn't want to go to the same places..");
      }
    }
  }
}
