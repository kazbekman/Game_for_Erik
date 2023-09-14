using UnityEngine;

namespace Main
{
    public class Level : Entity
    {
        [SerializeField] private LevelType _type;
        [SerializeField] private Element _element;
        [SerializeField] private int _maxCount;

        public void Generate()
        {
            switch (_type)
            {
                case LevelType.Common:
                    break;
                case LevelType.Generating:
                    break;
                default:
                    break;
            }
        }
    }
}