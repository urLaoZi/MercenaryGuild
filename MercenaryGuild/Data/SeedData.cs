using MercenaryGuild.Models;
using Microsoft.EntityFrameworkCore;

namespace MercenaryGuild.Data
{
    public static class SeedData
    {
        public static void Initialize(GuildDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Mercenaries.Any())
            {
                return;
            }

            var mercenaries = new List<Mercenary>
            {
                // Элита (SSS-S)
                new Mercenary {
                    Name = "GHOST-9",
                    Rank = Rank.SSS,
                    RegistrationDate = DateTime.Parse("2075-01-15"),
                    Bio = "Киберзомби с имплантами Mk.5. 97% тела заменено. Последнее задание: ликвидация CEO Arasaka."
                },
                new Mercenary {
                    Name = "NEON_JOY",
                    Rank = Rank.SS,
                    RegistrationDate = DateTime.Parse("2076-03-22"),
                    Bio = "Хакер-виртуоз. Взламывает Black ICE за 12 секунд. Имплант: нейролинк v4.2."
                },
                new Mercenary {
                    Name = "RUST_QUEEN",
                    Rank = Rank.SS,
                    RegistrationDate = DateTime.Parse("2075-11-05"),
                    Bio = "Королева дистанционных подрывов. Рекорд: 17 дронов за 3 минуты."
                },
                new Mercenary {
                    Name = "BINARY_KILL",
                    Rank = Rank.S,
                    RegistrationDate = DateTime.Parse("2076-07-18"),
                    Bio = "Специалист по тихим киберубийствам. Жертвы умирают от естественных причин."
                },
                new Mercenary {
                    Name = "CYBER_REV",
                    Rank = Rank.S,
                    RegistrationDate = DateTime.Parse("2077-02-10"),
                    Bio = "Бывший солдат спецназа. Бионика: 4 тактические руки, оптический камуфляж."
                },

                // Профессионалы (A-B)
                new Mercenary {
                    Name = "SYNTH_SHADOW",
                    Rank = Rank.A,
                    RegistrationDate = DateTime.Parse("2077-05-12"),
                    Bio = "Мастер инфильтрации. Никогда не попадал на камеры наблюдения."
                },
                new Mercenary {
                    Name = "GLITCH_GOD",
                    Rank = Rank.A,
                    RegistrationDate = DateTime.Parse("2077-08-30"),
                    Bio = "Гений цифрового саботажа. Может отключить весь район одним кодом."
                },
                new Mercenary {
                    Name = "RIOT_CODE",
                    Rank = Rank.B,
                    RegistrationDate = DateTime.Parse("2078-01-25"),
                    Bio = "Эксперт по горячим точкам. Любимое оружие: смарт-пулемёт."
                },
                new Mercenary {
                    Name = "VOID_WALK",
                    Rank = Rank.B,
                    RegistrationDate = DateTime.Parse("2078-03-17"),
                    Bio = "Спец по нестандартным решениям. 200+ успешных эксфильтраций."
                },
                new Mercenary {
                    Name = "DATA_REAPER",
                    Rank = Rank.C,
                    RegistrationDate = DateTime.Parse("2078-06-08"),
                    Bio = "Чёрный архивариус. Знает все корпоративные секреты Night City."
                },

                // Новички (D-E)
                new Mercenary {
                    Name = "PHANTOM_BYTE",
                    Rank = Rank.D,
                    RegistrationDate = DateTime.Parse("2079-02-14"),
                    Bio = "Начинающий хакер. Пока только взламывает банкоматы."
                },
                new Mercenary {
                    Name = "STATIC_KID",
                    Rank = Rank.D,
                    RegistrationDate = DateTime.Parse("2079-04-01"),
                    Bio = "Генетический эксперимент. Реакция в 3 раза быстрее нормы."
                },
                new Mercenary {
                    Name = "PULSE_ZERO",
                    Rank = Rank.E,
                    RegistrationDate = DateTime.Parse("2079-05-19"),
                    Bio = "Бывший уличный боец. Вживил себе дешёвые рефлексы."
                },
                new Mercenary {
                    Name = "NEURO_NOMAD",
                    Rank = Rank.E,
                    RegistrationDate = DateTime.Parse("2079-07-03"),
                    Bio = "Мечтает о нейроинтерфейсе. Пока работает на подхвате."
                },
                new Mercenary {
                    Name = "CRYO_SPIDER",
                    Rank = Rank.E,
                    RegistrationDate = DateTime.Parse("2079-09-27"),
                    Bio = "Фанат крио-оружия. Всегда носит заморозку."
                },

                // Специалисты
                new Mercenary {
                    Name = "TAROT_DEAL",
                    Rank = Rank.B,
                    RegistrationDate = DateTime.Parse("2077-10-31"),
                    Bio = "Предсказывает исходы с точностью 89%. Гарантирует 'интересную' смерть."
                },
                new Mercenary {
                    Name = "BLOOD_CPU",
                    Rank = Rank.A,
                    RegistrationDate = DateTime.Parse("2076-12-12"),
                    Bio = "Киберпсих с контролем. Убивает только по контракту."
                },
                new Mercenary {
                    Name = "OBSOLETE_SAINT",
                    Rank = Rank.C,
                    RegistrationDate = DateTime.Parse("2078-11-11"),
                    Bio = "Фанатик ретро-техники. Вооружён только оружием XX века."
                },
                new Mercenary {
                    Name = "DOLL_FACE",
                    Rank = Rank.S,
                    RegistrationDate = DateTime.Parse("2075-09-09"),
                    Bio = "Идеальный убийца. Жертвы умирают с улыбкой."
                },
                new Mercenary {
                    Name = "KARMA_OVERRIDE",
                    Rank = Rank.D,
                    RegistrationDate = DateTime.Parse("2079-08-15"),
                    Bio = "Бывший ИИ такси. Теперь ищет смысл жизни через убийства."
                }
            };

            context.Mercenaries.AddRange(mercenaries);
            context.SaveChanges();

            var quests = new List<Quest>
            {
                // Опасные миссии (SSS-A)
                new Quest {
                    Title = "ЛИКВИДАЦИЯ AI-ЯДРА",
                    Description = "Уничтожить экспериментальный ИИ Arasaka в Oceania Tower. Ожидается сопротивление: 5 киберпсихов, 12 дронов.",
                    Reward = 50000,
                    Rank = Rank.SSS,
                    Location = "Arasaka Tower, Oceania",
                    IsTaken = true,
                    MercenaryId = mercenaries[0].Id // GHOST-9
                },
                new Quest {
                    Title = "ОХОТА НА КИБЕРПСИХА",
                    Description = "Нейтрализовать бывшего солдата с экспериментальными имплантами в районе Watson. Цель убивает без разбора.",
                    Reward = 25000,
                    Rank = Rank.SS,
                    Location = "Watson District",
                    IsTaken = true,
                    MercenaryId = mercenaries[3].Id // BINARY_KILL
                },
                
                // Стандартные контракты
                new Quest {
                    Title = "КРАЖА ДАННЫХ MILITECH",
                    Description = "Извлечь данные из терминала с ICE-защитой 4-го уровня. Обеспечить чистый отход.",
                    Reward = 12000,
                    Rank = Rank.B,
                    Location = "Militech Facility"
                },
                new Quest {
                    Title = "ЛИКВИДАЦИЯ БОССА ОПГ",
                    Description = "Устранить лидера банды 'Tiger Claws'. Осторожно: личная охрана из 8 киборгов.",
                    Reward = 8000,
                    Rank = Rank.B,
                    Location = "Westbrook"
                },
                new Quest {
                    Title = "ОХРАНА КОРПОРАТИВА",
                    Description = "Сопровождение VIP из Kang Tao во время переговоров с Maelstrom. Возможна засада.",
                    Reward = 15000,
                    Rank = Rank.A,
                    Location = "City Center"
                },
                
                // Простые задания
                new Quest {
                    Title = "ДОСТАВКА ЧЕРНОГО ГРУЗА",
                    Description = "Перевезти контрабанду из Heywood в Pacifica. Вопросы не задавать. При сопротивлении — ликвидировать свидетелей.",
                    Reward = 3000,
                    Rank = Rank.D,
                    Location = "Heywood -> Pacifica"
                },
                new Quest {
                    Title = "ПОИСК УТЕРЯННОГО ДРОНА",
                    Description = "Найти разведывательный дрон с данными в Зоне Отчуждения. Осторожно: радиация и бандиты.",
                    Reward = 2000,
                    Rank = Rank.E,
                    Location = "Badlands"
                },
                
                // Спецзадания
                new Quest {
                    Title = "ВЗЛОМ БИОМЕТРИИ TRAUMA TEAM",
                    Description = "Подменить биометрические данные в системе экстренной помощи. Требуется хакер уровня 4+.",
                    Reward = 18000,
                    Rank = Rank.S,
                    Location = "Virtual Space"
                },
                new Quest {
                    Title = "КОМПРОМАТ НА ПОЛИТИКА",
                    Description = "Добыть доказательства связей с Night City gangs. Должно быть чисто — без убийств.",
                    Reward = 22000,
                    Rank = Rank.A,
                    Location = "City Hall"
                },
                new Quest {
                    Title = "ТЕСТИРОВАНИЕ НЕЙРОИНТЕРФЕЙСА",
                    Description = "Доброволец для испытаний импланта Biotechnica. Риск смерти 47%. Бонус за выживание.",
                    Reward = 35000,
                    Rank = Rank.SS,
                    Location = "Biotechnica Lab"
                }
            };

            context.Quests.AddRange(quests);
            context.SaveChanges();
        }
    }
}