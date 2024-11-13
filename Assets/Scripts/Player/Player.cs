using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public float distanceFromPlayer = 1f;
    private Item itemCurrent = null;
    public float pickupDistance = 2f;

    void FixedUpdate()
    {
        Move();
    }

    void Update()
    {
        Take();
    }

    private void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = transform.forward * verticalInput + transform.right * horizontalInput;
        transform.position += movement * speed * Time.deltaTime;
    }

    private void Take()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (itemCurrent == null)
            {
                Collider[] hitColliders = Physics.OverlapSphere(transform.position, pickupDistance);
                foreach (Collider collider in hitColliders)
                {
                    itemCurrent = collider.GetComponent<Item>();
                    if (itemCurrent != null)
                    {
                        PickupItem(itemCurrent);
                        break;
                    }
                }
            }
            else
            {
                DropItem(itemCurrent.rb);
            }
        }
    }

    void PickupItem(Item item)
    {
        item.transform.SetParent(transform);
        item.transform.localPosition = new Vector3(0f, distanceFromPlayer / 2, 0f);
        item.transform.localRotation = Quaternion.identity;
        itemCurrent.rb.constraints = RigidbodyConstraints.FreezeAll;
    }

    void DropItem(Rigidbody rigidbody)
    {
        if (itemCurrent != null)
        {
            itemCurrent.transform.SetParent(null);
            rigidbody.constraints = RigidbodyConstraints.None;
            itemCurrent.transform.position = transform.position + transform.forward * distanceFromPlayer;

            itemCurrent = null;
        }
    }
}

