using System;
using System.ComponentModel.DataAnnotations;
namespace TicTacToe
{
	public class Symbol
	{

		public enum Values
		{
			_,
			X,
			O
		}
		private Values _value;
		
		public Symbol(Values val)
		{
			_value = val;
		}
    }
}

