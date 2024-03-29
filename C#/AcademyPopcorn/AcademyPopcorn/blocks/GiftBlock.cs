﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class GiftBlock : Block
    {
        public GiftBlock(MatrixCoords topLeft)
            : base(topLeft)
        {

        }
        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
        }
        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<GameObject> gift = new List<GameObject>();
            if (IsDestroyed)
            {
                gift.Add(new Gift(this.topLeft));
            }
            return gift;
        }
    }
}
