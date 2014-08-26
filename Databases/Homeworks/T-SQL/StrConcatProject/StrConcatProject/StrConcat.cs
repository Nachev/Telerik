using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;
using System.Text;

[Serializable]
[Microsoft.SqlServer.Server.SqlUserDefinedAggregate(
    Format.UserDefined,
    MaxByteSize = 4000,
    IsInvariantToNulls = true,
    IsInvariantToDuplicates = false,
    IsNullIfEmpty = true)]
public struct StrConcat : IBinarySerialize
{
    private StringBuilder sb;

    public void Init()
    {
        sb = new StringBuilder();
    }

    public void Accumulate(SqlString Value)
    {
        if (!Value.IsNull)
        {
            sb.Append(Value).Append(", ");
        }
    }

    public void Merge(StrConcat Group)
    {
        sb.Append(Group.sb.ToString());
    }

    public SqlString Terminate()
    {
        if (sb.Length == 0)
        {
            return SqlString.Null;
        }
        else
        {
            sb.Remove(sb.Length - 2, 2);
            SqlString s = (SqlString)sb.ToString();
            return s;
        }
    }

    void IBinarySerialize.Read(System.IO.BinaryReader r)
    {
        sb = new StringBuilder();
        sb.Append(r.ReadString());
    }

    void IBinarySerialize.Write(System.IO.BinaryWriter w)
    {
        w.Write(sb.ToString());
    }
}