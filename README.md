# HashingBenchmark

Perforance difference on CPU between hashing algo.

.Net membership provider is SHA256 which is considered not secure

Identity Core is pbkdf2 with 1000 iteration (v3 used in .Net has 10k iterations)

BCrypt is slow on CPU and GPU but fast on FPGA.

Next, test SCrypt and Argon2