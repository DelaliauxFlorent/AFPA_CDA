<?php
// Entity/Products.php
namespace App\Entity;

use Doctrine\ORM\Mapping as ORM;

/**
 * @ORM\Entity
 * @ORM\Table(name="products")
 */
class Products
{
    /**
     * @ORM\Column(name="ProductID", type="integer", nullable=false)
     * @ORM\Id
     * @ORM\GeneratedValue(strategy="IDENTITY")
     */
    private $id;

    /**
     * @ORM\Column(name="ProductName", type="string", length=40)
     */
    private $name;

    /**
     * @ORM\Column(name="SupplierID", type="integer")
     */
    private $supplierId;

    /**
     * @ORM\Column(name="CategoryID", type="integer")
     */
    private $categoryId;

    /**
     * @ORM\Column(name="QuantityPerUnit", type="string", length=20)
     */
    private $quantityPerUnit;

    /**
     * @ORM\Column(name="UnitPrice", type="float")
     */
    private $prixUnitaire;

    /**
     * @ORM\Column(name="UnitsInStock", type="integer")
     */
    private $qteStock;

    /**
     * @ORM\Column(name="UnitsOnOrder", type="integer")
     */
    private $qteCommande;

    /**
     * @ORM\Column(name="ReorderLevel", type="integer")
     */
    private $nivRestock;

    /**
     * @ORM\Column(name="Discontinued", type="boolean")
     */
    private $arrete;

    /**
     * @var \Suppliers
     * 
     * @ORM\ManyToOne(targetEntity="Suppliers", inversedBy="products")
     * @ORM\JoinColumn(name="SupplierId", referencedColumnName="SupplierId")
     * 
     */
    private $suppliers;
    
    public function getId(): ?int
    {
        return $this->id;
    }

    public function getName(): ?string
    {
        return $this->name;
    }

    public function setName(string $name): self
    {
        $this->name = $name;
        return $this;
    }

    public function getSupplierId(): ?int
    {
        return $this->supplierId;
    }

    public function setSupplierId($supplierId): self
    {
        $this->supplierId = $supplierId;
        return $this;
    }

    public function getCategoryId(): ?int
    {
        return $this->categoryId;
    }

    public function setCategoryId($categoryId): self
    {
        $this->categoryId = $categoryId;
        return $this;
    }

    public function getQuantityPerUnit(): ?string
    {
        return $this->quantityPerUnit;
    }

    public function setQuantityPerUnit($quantityPerUnit): self
    {
        $this->quantityPerUnit = $quantityPerUnit;
        return $this;
    }

    public function getPrixUnitaire(): ?float
    {
        return $this->prixUnitaire;
    }

    public function setPrixUnitaire($prixUnitaire): self
    {
        $this->prixUnitaire = $prixUnitaire;
        return $this;
    }

    public function getQteStock(): ?int
    {
        return $this->qteStock;
    }

    public function setQteStock($qteStock): self
    {
        $this->qteStock = $qteStock;
        return $this;
    }

    public function getQteCommande(): ?int
    {
        return $this->qteCommande;
    }

    public function setQteCommande($qteCommande): self
    {
        $this->qteCommande = $qteCommande;
        return $this;
    }

    public function getNivRestock(): ?int
    {
        return $this->nivRestock;
    }

    public function setNivRestock($nivRestock): self
    {
        $this->nivRestock = $nivRestock;
        return $this;
    }

    public function getArrete(): ?bool
    {
        return $this->arrete;
    }

    public function setArrete($arrete): self
    {
        $this->arrete = $arrete;
        return $this;
    }

    public function getSuppliers()
    {
        return $this->suppliers;
    }

    public function setSuppliers(?Suppliers $supplier):self
    {
        $this->suppliers = $supplier;
        return $this;
    }
}
