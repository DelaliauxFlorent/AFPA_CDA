<?php

namespace App\Entity;

use App\Repository\ProductsRepository;
use Doctrine\Common\Collections\ArrayCollection;
use Doctrine\Common\Collections\Collection;
use Doctrine\DBAL\Types\Types;
use Doctrine\ORM\Mapping as ORM;

#[ORM\Entity(repositoryClass: ProductsRepository::class)]
class Products
{
    #[ORM\Id]
    #[ORM\GeneratedValue]
    #[ORM\Column]
    private ?int $id = null;

    #[ORM\Column(length: 40)]
    private ?string $ProductName = null;

    #[ORM\Column(nullable: true)]
    private ?int $CategoryID = null;

    #[ORM\Column(length: 20, nullable: true)]
    private ?string $QuantityPerUnit = null;

    #[ORM\Column(type: Types::DECIMAL, precision: 10, scale: 4, nullable: true, options:["default"=>"0.0000"])]
    private ?string $UnitPrice = "0.0000";

    #[ORM\Column(type: Types::SMALLINT, nullable: true, options:["default"=>0])]
    private ?int $UnitsInStock = 0;

    #[ORM\Column(type: Types::SMALLINT, nullable: true, options:["default"=>0])]
    private ?int $UnitsOnOrder = 0;

    #[ORM\Column(type: Types::SMALLINT, nullable: true, options:["default"=>0])]
    private ?int $ReorderLevel = 0;

    #[ORM\Column(options:["default"=>false])]
    private ?bool $Discontinued = false;

    #[ORM\ManyToOne(inversedBy: 'Products')]
    private ?Suppliers $Supplier = null;

    #[ORM\OneToMany(mappedBy: 'ProductID', targetEntity: OrderDetails::class)]
    private Collection $OrderDetails;

    public function __construct()
    {
        $this->OrderDetails = new ArrayCollection();
    }

    public function getId(): ?int
    {
        return $this->id;
    }

    public function getProductName(): ?string
    {
        return $this->ProductName;
    }

    public function setProductName(string $ProductName): self
    {
        $this->ProductName = $ProductName;

        return $this;
    }

    public function getCategoryID(): ?int
    {
        return $this->CategoryID;
    }

    public function setCategoryID(?int $CategoryID): self
    {
        $this->CategoryID = $CategoryID;

        return $this;
    }

    public function getQuantityPerUnit(): ?string
    {
        return $this->QuantityPerUnit;
    }

    public function setQuantityPerUnit(?string $QuantityPerUnit): self
    {
        $this->QuantityPerUnit = $QuantityPerUnit;

        return $this;
    }

    public function getUnitPrice(): ?string
    {
        return $this->UnitPrice;
    }

    public function setUnitPrice(?string $UnitPrice): self
    {
        $this->UnitPrice = $UnitPrice;

        return $this;
    }

    public function getUnitsInStock(): ?int
    {
        return $this->UnitsInStock;
    }

    public function setUnitsInStock(?int $UnitsInStock): self
    {
        $this->UnitsInStock = $UnitsInStock;

        return $this;
    }

    public function getUnitsOnOrder(): ?int
    {
        return $this->UnitsOnOrder;
    }

    public function setUnitsOnOrder(?int $UnitsOnOrder): self
    {
        $this->UnitsOnOrder = $UnitsOnOrder;

        return $this;
    }

    public function getReorderLevel(): ?int
    {
        return $this->ReorderLevel;
    }

    public function setReorderLevel(?int $ReorderLevel): self
    {
        $this->ReorderLevel = $ReorderLevel;

        return $this;
    }

    public function isDiscontinued(): ?bool
    {
        return $this->Discontinued;
    }

    public function setDiscontinued(bool $Discontinued): self
    {
        $this->Discontinued = $Discontinued;

        return $this;
    }

    public function getSupplier(): ?Suppliers
    {
        return $this->Supplier;
    }

    public function setSupplier(?Suppliers $Supplier): self
    {
        $this->Supplier = $Supplier;

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
            $orderDetail->setProductID($this);
        }

        return $this;
    }

    public function removeOrderDetail(OrderDetails $orderDetail): self
    {
        if ($this->OrderDetails->removeElement($orderDetail)) {
            // set the owning side to null (unless already changed)
            if ($orderDetail->getProductID() === $this) {
                $orderDetail->setProductID(null);
            }
        }

        return $this;
    }

    public function __toString()
    {
        return $this->ProductName;
    }
}
