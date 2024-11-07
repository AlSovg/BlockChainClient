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
    public class BlockComparer : IEqualityComparer<BlockViewModel>
    {
        public bool Equals(BlockViewModel x, BlockViewModel y)
        {
            return x.BlockId == y.BlockId &&
                   x.CurHash == y.CurHash &&
                   x.PrevHash == y.PrevHash &&
                   x.ValidCount == y.ValidCount &&
                   x.GenesisBlock == y.GenesisBlock;
        }

        public int GetHashCode(BlockViewModel obj)
        {
            int hash = 17;
            hash = hash * 23 + obj.BlockId.GetHashCode();
            hash = hash * 23 + (obj.CurHash?.GetHashCode() ?? 0);
            hash = hash * 23 + (obj.PrevHash?.GetHashCode() ?? 0);
            hash = hash * 23 + obj.ValidCount.GetHashCode();
            hash = hash * 23 + obj.GenesisBlock.GetHashCode();
            return hash;
        }
    }
}