<?php

namespace App\Entity;

use App\Repository\OrdersRepository;
use Doctrine\Common\Collections\ArrayCollection;
use Doctrine\Common\Collections\Collection;
use Doctrine\DBAL\Types\Types;
use Doctrine\ORM\Mapping as ORM;

#[ORM\Entity(repositoryClass: OrdersRepository::class)]
class Orders
{
    #[ORM\Id]
    #[ORM\GeneratedValue]
    #[ORM\Column]
    private ?int $id = null;

    #[ORM\Column(nullable: true)]
    private ?int $EmployeeID = null;

    #[ORM\Column(type: Types::DATETIME_MUTABLE, nullable: true)]
    private ?\DateTimeInterface $OrderDate = null;

    #[ORM\Column(type: Types::DATETIME_MUTABLE, nullable: true)]
    private ?\DateTimeInterface $RequiredDate = null;

    #[ORM\Column(type: Types::DATETIME_MUTABLE, nullable: true)]
    private ?\DateTimeInterface $ShippedDate = null;

    #[ORM\Column(nullable: true)]
    private ?int $ShipVia = null;

    #[ORM\Column(type: Types::DECIMAL, precision: 10, scale: 4, nullable: true, options:["default"=>"0.0000"])]
    private ?string $Freight = "0.0000";

    #[ORM\Column(length: 40, nullable: true)]
    private ?string $ShipName = null;

    #[ORM\Column(length: 60, nullable: true)]
    private ?string $ShipAddress = null;

    #[ORM\Column(length: 15, nullable: true)]
    private ?string $ShipCity = null;

    #[ORM\Column(length: 15, nullable: true)]
    private ?string $ShipRegion = null;

    #[ORM\Column(length: 10, nullable: true)]
    private ?string $ShipPostalCode = null;

    #[ORM\Column(length: 15, nullable: true)]
    private ?string $ShipCountry = null;

    #[ORM\ManyToOne(inversedBy: 'Orders')]
    private ?Customers $CustomerID = null;

    #[ORM\OneToMany(mappedBy: 'OrderID', targetEntity: OrderDetails::class)]
    private Collection $OrderDetails;

    public function __construct()
    {
        $this->OrderDetails = new ArrayCollection();
    }

    public function getId(): ?int
    {
        return $this->id;
    }

    public function getEmployeeID(): ?int
    {
        return $this->EmployeeID;
    }

    public function setEmployeeID(?int $EmployeeID): self
    {
        $this->EmployeeID = $EmployeeID;

        return $this;
    }

    public function getOrderDate(): ?\DateTimeInterface
    {
        return $this->OrderDate;
    }

    public function setOrderDate(?\DateTimeInterface $OrderDate): self
    {
        $this->OrderDate = $OrderDate;

        return $this;
    }

    public function getRequiredDate(): ?\DateTimeInterface
    {
        return $this->RequiredDate;
    }

    public function setRequiredDate(?\DateTimeInterface $RequiredDate): self
    {
        $this->RequiredDate = $RequiredDate;

        return $this;
    }

    public function getShippedDate(): ?\DateTimeInterface
    {
        return $this->ShippedDate;
    }

    public function setShippedDate(?\DateTimeInterface $ShippedDate): self
    {
        $this->ShippedDate = $ShippedDate;

        return $this;
    }

    public function getShipVia(): ?int
    {
        return $this->ShipVia;
    }

    public function setShipVia(?int $ShipVia): self
    {
        $this->ShipVia = $ShipVia;

        return $this;
    }

    public function getFreight(): ?string
    {
        return $this->Freight;
    }

    public function setFreight(?string $Freight): self
    {
        $this->Freight = $Freight;

        return $this;
    }

    public function getShipName(): ?string
    {
        return $this->ShipName;
    }

    public function setShipName(?string $ShipName): self
    {
        $this->ShipName = $ShipName;

        return $this;
    }

    public function getShipAddress(): ?string
    {
        return $this->ShipAddress;
    }

    public function setShipAddress(?string $ShipAddress): self
    {
        $this->ShipAddress = $ShipAddress;

        return $this;
    }

    public function getShipCity(): ?string
    {
        return $this->ShipCity;
    }

    public function setShipCity(?string $ShipCity): self
    {
        $this->ShipCity = $ShipCity;

        return $this;
    }

    public function getShipRegion(): ?string
    {
        return $this->ShipRegion;
    }

    public function setShipRegion(?string $ShipRegion): self
    {
        $this->ShipRegion = $ShipRegion;

        return $this;
    }

    public function getShipPostalCode(): ?string
    {
        return $this->ShipPostalCode;
    }

    public function setShipPostalCode(?string $ShipPostalCode): self
    {
        $this->ShipPostalCode = $ShipPostalCode;

        return $this;
    }

    public function getShipCountry(): ?string
    {
        return $this->ShipCountry;
    }

    public function setShipCountry(?string $ShipCountry): self
    {
        $this->ShipCountry = $ShipCountry;

        return $this;
    }

    public function getCustomerID(): ?Customers
    {
        return $this->CustomerID;
    }

    public function setCustomerID(?Customers $CustomerID): self
    {
        $this->CustomerID = $CustomerID;

        return $this;
    }

    /**
     * @return Collection<int, OrderDetails>
     */
    public function getOrderDetails(): Collection
    {
        return $this->OrderDetails;
    }

    public function addOrderDetail(OrderDetails $orderDetail): self
    {
        if (!$this->OrderDetails->contains($orderDetail)) {
            $this->OrderDetails->add($orderDetail);
            $orderDetail->setOrderID($this);
        }

        return $this;
    }

    public function removeOrderDetail(OrderDetails $orderDetail): self
    {
        if ($this->OrderDetails->removeElement($orderDetail)) {
            // set the owning side to null (unless already changed)
            if ($orderDetail->getOrderID() === $this) {
                $orderDetail->setOrderID(null);
            }
        }

        return $this;
    }
}
