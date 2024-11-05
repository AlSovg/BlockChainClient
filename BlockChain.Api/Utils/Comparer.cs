using BlockChain.Domain.Models.Request;

namespace BlockChain.Api.Utils;

public class Comparer
{
    public class UserComparer : IEqualityComparer<UserViewModel>
    {
        public bool Equals(UserViewModel x, UserViewModel y)
        {
            return x.UserId == y.UserId &&
                   x.Hash == y.Hash &&
                   x.Coins == y.Coins &&
                   x.CurlId == y.CurlId;
        }
        public int GetHashCode(UserViewModel obj)
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + obj.UserId.GetHashCode();
                hash = hash * 23 + (obj.Hash ?? string.Empty).GetHashCode();
                hash = hash * 23 + obj.Coins.GetHashCode();
                hash = hash * 23 + (obj.CurlId ?? string.Empty).GetHashCode();
                return hash;
            }
        }
    }
}