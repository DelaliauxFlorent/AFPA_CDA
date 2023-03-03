<?php

namespace App\Entity;

use App\Repository\CustomersRepository;
use Doctrine\Common\Collections\ArrayCollection;
use Doctrine\Common\Collections\Collection;
use Doctrine\ORM\Mapping as ORM;

#[ORM\Entity(repositoryClass: CustomersRepository::class)]
class Customers
{
    #[ORM\Id]
    #[ORM\GeneratedValue(strategy:"NONE")]
    #[ORM\Column(length: 5)]
    private ?string $id = null;

    #[ORM\Column(length: 40)]
    private ?string $CompanyName = null;

    #[ORM\Column(length: 30, nullable: true)]
    private ?string $ContactName = null;

    #[ORM\Column(length: 30, nullable: true)]
    private ?string $ContactTitle = null;

    #[ORM\Column(length: 60, nullable: true)]
    private ?string $Address = null;

    #[ORM\Column(length: 15, nullable: true)]
    private ?string $City = null;

    #[ORM\Column(length: 15, nullable: true)]
    private ?string $Region = null;

    #[ORM\Column(length: 10, nullable: true)]
    private ?string $PostalCode = null;

    #[ORM\Column(length: 15, nullable: true)]
    private ?string $Country = null;

    #[ORM\Column(length: 24, nullable: true)]
    private ?string $Phone = null;

    #[ORM\Column(length: 24, nullable: true)]
    private ?string $Fax = null;

    #[ORM\OneToMany(mappedBy: 'CustomerID', targetEntity: Orders::class)]
    private Collection $Orders;

    public function __construct()
    {
        $this->Orders = new ArrayCollection();
    }

    public function getId(): ?string
    {
        return $this->id;
    }

    public function getCompanyName(): ?string
    {
        return $this->CompanyName;
    }

    public function setCompanyName(string $CompanyName): self
    {
        $this->CompanyName = $CompanyName;

        return $this;
    }

    public function getContactName(): ?string
    {
        return $this->ContactName;
    }

    public function setContactName(?string $ContactName): self
    {
        $this->ContactName = $ContactName;

        return $this;
    }

    public function getContactTitle(): ?string
    {
        return $this->ContactTitle;
    }

    public function setContactTitle(?string $ContactTitle): self
    {
        $this->ContactTitle = $ContactTitle;

        return $this;
    }

    public function getAddress(): ?string
    {
        return $this->Address;
    }

    public function setAddress(?string $Address): self
    {
        $this->Address = $Address;

        return $this;
    }

    public function getCity(): ?string
    {
        return $this->City;
    }

    public function setCity(?string $City): self
    {
        $this->City = $City;

        return $this;
    }

    public function getRegion(): ?string
    {
        return $this->Region;
    }

    public function setRegion(?string $Region): self
    {
        $this->Region = $Region;

        return $this;
    }

    public function getPostalCode(): ?string
    {
        return $this->PostalCode;
    }

    public function setPostalCode(?string $PostalCode): self
    {
        $this->PostalCode = $PostalCode;

        return $this;
    }

    public function getCountry(): ?string
    {
        return $this->Country;
    }

    public function setCountry(?string $Country): self
    {
        $this->Country = $Country;

        return $this;
    }

    public function getPhone(): ?string
    {
        return $this->Phone;
    }

    public function setPhone(?string $Phone): self
    {
        $this->Phone = $Phone;

        return $this;
    }

    public function getFax(): ?string
    {
        return $this->Fax;
    }

    public function setFax(?string $Fax): self
    {
        $this->Fax = $Fax;

        return $this;
    }

    /**
     * @return Collection<int, Orders>
     */
    public function getOrders(): Collection
    {
        return $this->Orders;
    }

    public function addOrder(Orders $order): self
    {
        if (!$this->Orders->contains($order)) {
            $this->Orders->add($order);
            $order->setCustomerID($this);
        }

        return $this;
    }

    public function removeOrder(Orders $order): self
    {
        if ($this->Orders->removeElement($order)) {
            // set the owning side to null (unless already changed)
            if ($order->getCustomerID() === $this) {
                $order->setCustomerID(null);
            }
        }

        return $this;
    }
    
    public function __toString()
    {
        return $this->CompanyName;
    }
}
