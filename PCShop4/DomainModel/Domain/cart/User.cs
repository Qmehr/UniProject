using System;
using System.Collections.Generic;
using System.Linq;

namespace DomainModel
{
    public class User
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public IEnumerable<Guid> CartId { get; private set; } = new List<Guid>();
        public void AddCart(Guid cartId)
        {
            var temp = CartId.ToList();
            temp.Add(cartId);
            CartId = temp;
        }
        public void RemoveCart(Guid cartId)
        {
            var temp = CartId.Where(c => c != cartId).ToList();
            CartId = temp;
        }
    }
}