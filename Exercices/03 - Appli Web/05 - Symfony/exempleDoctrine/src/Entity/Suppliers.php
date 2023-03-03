<?php

namespace App\Entity;

use App\Repository\SuppliersRepository;
use Doctrine\Common\Collections\ArrayCollection;
use Doctrine\Common\Collections\Collection;
use Doctrine\DBAL\Types\Types;
use Doctrine\ORM\Mapping as ORM;
use Symfony\Component\Validator\Constraints as Assert;

#[ORM\Entity(repositoryClass: SuppliersRepository::class)]
class Suppliers
{
    #[ORM\Id]
    #[ORM\GeneratedValue]
    #[ORM\Column]
    private ?int $id = null;

    #[ORM\Column(type: "string", length: 40)]
    #[Assert\NotBlank(message:"Veuillez renseigner le nom du fournisseur")]
    #[Assert\Regex(
        pattern:'/^[\s\w\#\_\-éèàçâêîôûùäaëïüö]+$/',
        message:"Caractère(s) non valide(s)"
    )]
    private ?string $CompanyName = null;

    #[ORM\Column(length: 30, nullable: true)]
    #[Assert\Regex(
        pattern:'/^[\s\w\#\_\-éèàçâêîôûùäaëïüö]+$/',
        message:"Caractère(s) non valide(s)"
    )]
    private ?string $ContactName = null;

    #[ORM\Column(length: 30, nullable: true)]
    #[Assert\Regex(
        pattern:'/^[\s\w\#\_\-éèàçâêîôûùäaëïüö]+$/',
        message:"Caractère(s) non valide(s)"
    )]
    private ?string $ContactTitle = null;

    #[ORM\Column(length: 60, nullable: true)]
    #[Assert\Regex(
        pattern:'/^[\s\w\#\_\-éèàçâêîôûùäaëïüö]+$/',
        message:"Caractère(s) non valide(s)"
    )]
    private ?string $Address = null;

    #[ORM\Column(length: 15, nullable: true)]
    #[Assert\Regex(
        pattern:'/^[\s\w\#\_\-éèàçâêîôûùäaëïüö]+$/',
        message:"Caractère(s) non valide(s)"
    )]
    private ?string $City = null;

    #[ORM\Column(length: 15, nullable: true)]
    #[Assert\Regex(
        pattern:'/^[\s\w\#\_\-éèàçâêîôûùäaëïüö]+$/',
        message:"Caractère(s) non valide(s)"
    )]
    private ?string $Region = null;

    #[ORM\Column(length: 10, nullable: true)]
    #[Assert\Regex(
        pattern:'/^\d{5,10}$/',
        message:"Caractère(s) non valide(s)"
    )]
    private ?string $PostalCode = null;

    #[ORM\Column(length: 15, nullable: true)]
    #[Assert\Regex(
        pattern:'/^[\s\w\#\_\-éèàçâêîôûùäaëïüö]+$/',
        message:"Caractère(s) non valide(s)"
    )]
    private ?string $Country = null;

    #[ORM\Column(length: 24, nullable: true)]
    #[Assert\Regex(
        pattern:'/^(+33|0)\d((\.| )?\d{2}){4}$/',
        message:"Caractère(s) non valide(s)"
    )]
    private ?string $Phone = null;

    #[ORM\Column(length: 24, nullable: true)]
    #[Assert\Regex(
        pattern:'/^(+33|0)\d((\.| )?\d{2}){4}$/',
        message:"Caractère(s) non valide(s)"
    )]
    private ?string $Fax = null;

    #[ORM\Column(type: Types::TEXT, nullable: true)]
    private ?string $HomePage = null;

    #[ORM\OneToMany(mappedBy: 'Supplier', targetEntity: Products::class)]
    private Collection $Products;

    public function __construct()
    {
        $this->Products = new ArrayCollection();
    }

    public function getId(): ?int
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

    public function getHomePage(): ?string
    {
        return $this->HomePage;
    }

    public function setHomePage(?string $HomePage): self
    {
        $this->HomePage = $HomePage;

        return $this;
    }

    /**
     * @return Collection<int, Products>
     */
    public function getProducts(): Collection
    {
        return $this->Products;
    }

    public function addProduct(Products $product): self
    {
        if (!$this->Products->contains($product)) {
            $this->Products->add($product);
            $product->setSupplier($this);
        }

        return $this;
    }

    public function removeProduct(Products $product): self
    {
        if ($this->Products->removeElement($product)) {
            // set the owning side to null (unless already changed)
            if ($product->getSupplier() === $this) {
                $product->setSupplier(null);
            }
        }

        return $this;
    }

    public function __toString()
    {
        return $this->CompanyName;
    }
}
