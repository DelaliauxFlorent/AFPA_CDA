<?php

namespace App\Form;

use App\Entity\Products;
use Symfony\Component\Form\AbstractType;
use Symfony\Component\Form\Extension\Core\Type\CheckboxType;
use Symfony\Component\Form\Extension\Core\Type\ChoiceType;
use Symfony\Component\Form\Extension\Core\Type\IntegerType;
use Symfony\Component\Form\Extension\Core\Type\MoneyType;
use Symfony\Component\Form\Extension\Core\Type\TextType;
use Symfony\Component\Form\FormBuilderInterface;
use Symfony\Component\OptionsResolver\OptionsResolver;
use Symfony\Component\Validator\Constraints\Regex;

class ProductsType extends AbstractType
{
    public function buildForm(FormBuilderInterface $builder, array $options): void
    {
        $builder
            ->add('ProductName', TextType::class, [
                'label' => 'Nom du produit',
                'attr' => [
                    'placeholder' => 'Produit',
                ],
                'constraints' => [
                    new Regex([
                        'pattern' => '/^[A-Za-zéèàçâêûîôäëüïö\_\-\s]+$/',
                        'message' => 'Caractère(s) non valide(s)'
                    ]),
                ],
                'help' => 'Vous devez rentrer le nom du produit ici',
            ])
            ->add('Supplier', null, [
                'label'=> 'Nom du fournisseur',
                'help' => 'Vous devez sélectionner le fournisseur du produit ici',
            ])
            ->add('CategoryID', IntegerType::class, [
                'label' => 'Id de la catégorie',
            ])
            ->add('QuantityPerUnit', TextType::class, [
                'label' => 'Quantit par unité',
                'attr' => [
                    'placeholder' => 'Quantité par unité',
                ],
                'constraints' => [
                    new Regex([
                        'pattern' => '/^[A-Za-zéèàçâêûîôäëüïö\_\-\s]+$/',
                        'message' => 'Caractère(s) non valide(s)'
                    ]),
                ],
            ])
            ->add('UnitPrice', MoneyType::class, [
                'label'=> 'Prix unitaire',
                'attr'=>[
                    'placeholder' => 'Prix unitaire',
                ],
            ])
            ->add('UnitsInStock', IntegerType::class, [
                'label' => 'Quantité en stock', 
                'attr' => [
                    'placeholder' => 'Stock',
                ],
            ])
            ->add('UnitsOnOrder', IntegerType::class, [
                'label' => 'Quantité en commande',
                'attr' => [
                    'placeholder' => 'Quantité en commande'
                ],
            ])
            ->add('ReorderLevel', IntegerType::class, [
                'label' => 'Niveau d\'alerte',
                'attr' => [
                    'placeholder' => 'Niveau d\'alerte'
                ],
            ])
            ->add('Discontinued', CheckboxType::class, [
                'label' => 'Arrété',
                'label_attr' => [
                    'class' => 'checkbox-inline checkbox-switch',
                ],
            ])
        ;
    }

    public function configureOptions(OptionsResolver $resolver): void
    {
        $resolver->setDefaults([
            'data_class' => Products::class,
        ]);
    }
}
