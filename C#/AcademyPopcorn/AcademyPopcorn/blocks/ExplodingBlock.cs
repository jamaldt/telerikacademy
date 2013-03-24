using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class ExplodingBlock : Block
    {
        public new const string CollisionGroupString = "explodingBlock";

        public const char Symbol = 'e';

        public ExplodingBlock(MatrixCoords upperLeft)
            : base(upperLeft)
        {
            this.body[0, 0] = Symbol;
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            base.RespondToCollision(collisionData);
        }

        public override string GetCollisionGroupString()
        {
            return CollisionGroupString;
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<GameObject> exp = new List<GameObject>();
            if (IsDestroyed)
            {
                exp.Add(new Explosion(topLeft, new char[,] { { 'b' } }, new MatrixCoords(-1, 0)));
                exp.Add(new Explosion(topLeft, new char[,] { { 'b' } }, new MatrixCoords(1, 0)));
                exp.Add(new Explosion(topLeft, new char[,] { { 'b' } }, new MatrixCoords(0, 1)));
                exp.Add(new Explosion(topLeft, new char[,] { { 'b' } }, new MatrixCoords(0, -1)));
            }
            return exp;
        }
    }
}
