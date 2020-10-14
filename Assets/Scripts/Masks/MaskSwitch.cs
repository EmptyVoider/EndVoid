using UnityEngine;

namespace Masks
{
    public class MaskSwitch : MonoBehaviour
    {
        public SpriteRenderer FrontImage;
        public SpriteRenderer Backimage;
        public SpriteRenderer LeftImage;
        public SpriteRenderer RightImage;

        public void PutMask(MaskInfo maskInfo)
        {
            FrontImage.sprite = maskInfo.FrontSprite;
            Backimage.sprite = maskInfo.BackSprite;
            LeftImage.sprite = maskInfo.LeftSprite;
            RightImage.sprite = maskInfo.RightSprite;
        }

        public void FaceLeft()
        {
            FrontImage.gameObject.SetActive(false);
            Backimage.gameObject.SetActive(false);
            LeftImage.gameObject.SetActive(true);
            RightImage.gameObject.SetActive(false);
        }
    
        public void FaceRight()
        {
            FrontImage.gameObject.SetActive(false);
            Backimage.gameObject.SetActive(false);
            LeftImage.gameObject.SetActive(false);
            RightImage.gameObject.SetActive(true);
        } 
    
        public void FaceDown()
        {
            FrontImage.gameObject.SetActive(true);
            Backimage.gameObject.SetActive(false);
            LeftImage.gameObject.SetActive(false);
            RightImage.gameObject.SetActive(false);
        }
    
        public void FaceUp()
        {
            FrontImage.gameObject.SetActive(false);
            Backimage.gameObject.SetActive(true);
            LeftImage.gameObject.SetActive(false);
            RightImage.gameObject.SetActive(false);
        }


        public void SwitchForMovement(Vector2 movement)
        {
            if (movement.y > 0)
            {
                FaceUp();
                return;
            }
            if (movement.x > 0)
            {
                FaceRight();
                return;
            }
            if (movement.x < 0)
            {
                FaceLeft();
                return;
            }
            FaceDown();
        
        }
    }
}
