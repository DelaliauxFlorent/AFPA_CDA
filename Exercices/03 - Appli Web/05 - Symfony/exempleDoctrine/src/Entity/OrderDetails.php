<?php

namespace App\Entity;

use App\Repository\OrderDetailsRepository;
use Doctrine\DBAL\Types\Types;
use Doctrine\ORM\Mapping as ORM;

#[ORM\Entity(repositoryClass: OrderDetailsRepository::class)]
class OrderDetails
{
    #[ORM\Id]
    #[ORM\GeneratedValue]
    #[ORM\Column]
    private ?int $id = null;

    #[ORM\Column(type: Types::DECIMAL, precision: 10, scale: 4)]
    private ?string $UnitPrice = null;

    #[ORM\Column(type: Types::SMALLINT)]
    private ?int $Quantity = null;

    #[ORM\Column]
    private ?float $Discount = null;

    #[ORM\ManyToOne(inversedBy: 'OrderDetails')]
    #[ORM\JoinColumn(nullable: false)]
    private ?Orders $OrderID = null;

    #[ORM\ManyToOne(inversedBy: 'OrderDetails')]
    #[ORM\JoinColumn(nullable: false)]
    private ?Products $ProductID = null;

    public function getId(): ?int
    {
        return $this->id;
    }

    public function getUnitPrice(): ?string
    {
        return $this->UnitPrice;
    }

    public function setUnitPrice(string $UnitPrice): self
    {
        $this->UnitPrice = $UnitPrice;

        return $this;
    }

    public function getQuantity(): ?int
    {
        return $this->Quantity;
    }

    public function setQuantity(int $Quantity): self
    {
        $this->Quantity = $Quantity;

        return $this;
    }

    public function getDiscount(): ?float
    {
        return $this->Discount;
    }

    public function setDiscount(float $Discount): self
    {
        $this->Discount = $Discount;

        return $this;
    }

    public function getOrderID(): ?Orders
    {
        return $this->OrderID;
    }

    public function setOrderID(?Orders $OrderID): self
    {
        $this->OrderID = $OrderID;

        return $this;
    }

    public function getProductID(): ?Products
    {
        return $this->ProductID;
    }

    public function setProductID(?Products $ProductID): self
    {
        $this->ProductID = $ProductID;

        return $this;
    }

    public function __toString()
    {
        return $this->id;
    }
}
