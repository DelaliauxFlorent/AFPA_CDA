<?php

declare(strict_types=1);

namespace DoctrineMigrations;

use Doctrine\DBAL\Schema\Schema;
use Doctrine\Migrations\AbstractMigration;

/**
 * Auto-generated Migration: Please modify to your needs!
 */
final class Version20230301152600 extends AbstractMigration
{
    public function getDescription(): string
    {
        return '';
    }

    public function up(Schema $schema): void
    {
        // this up() migration is auto-generated, please modify it to your needs
        $this->addSql('ALTER TABLE products CHANGE discontinued discontinued TINYINT(1) NOT NULL');
        $this->addSql('ALTER TABLE products RENAME INDEX idx_b3ba5a5aa65f9c7d TO IDX_B3BA5A5A2ADD6D8C');
    }

    public function down(Schema $schema): void
    {
        // this down() migration is auto-generated, please modify it to your needs
        $this->addSql('ALTER TABLE products CHANGE discontinued discontinued TINYINT(1) DEFAULT 0 NOT NULL');
        $this->addSql('ALTER TABLE products RENAME INDEX idx_b3ba5a5a2add6d8c TO IDX_B3BA5A5AA65F9C7D');
    }
}
